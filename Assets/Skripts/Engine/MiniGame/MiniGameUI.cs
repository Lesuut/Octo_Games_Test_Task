using DTT.MinigameMemory;
using Naninovel;
using Naninovel.UI;
using UnityEngine;

namespace NaninovelMiniGame
{
    public class MiniGameUI : CustomUI
    {
        [SerializeField] private MemoryGameManager gameManager;
        [SerializeField] private MemoryGameSettings memoryGameSettings;

        private MiniGameManager inventoryManager;
        private IScriptPlayer scriptPlayer;
        private IUIManager uiManager;

        protected override void Awake()
        {
            base.Awake();

            inventoryManager = Engine.GetService<MiniGameManager>();
            scriptPlayer = Engine.GetService<IScriptPlayer>();
            uiManager = Engine.GetService<IUIManager>();
        }

        public async UniTask StartMiniGame(string SettingID, AsyncToken asyncToken = default)
        {
            var miniGameUi = uiManager.GetUI(inventoryManager.GetMiniGameUIItemID());
            miniGameUi.Show();

            gameManager.StartGame(memoryGameSettings);

            //gameManager.StartGame(await inventoryManager.GetItemGameSettingsAsync(SettingID));
        }
    }
}
