using DTT.MinigameMemory;
using DTT.Utils.Extensions;
using Naninovel;
using Naninovel.UI;
using UnityEngine;

namespace NaninovelMiniGame
{
    public class MiniGameUI : CustomUI
    {
        [SerializeField] private MemoryGameManager gameManager;
        [SerializeField] private PlayScript gameScript;

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

        public async UniTask StartMiniGame(string SettingID, string ScriptName, string ScriptText, AsyncToken asyncToken = default)
        {
            var miniGameUi = uiManager.GetUI(inventoryManager.GetMiniGameUIItemID());
            miniGameUi.Show();

            gameManager.StartGame(await inventoryManager.GetItemGameSettingsAsync(SettingID));

            // Создаем UniTaskCompletionSource для ожидания завершения игры
            var finishCompletionSource = new UniTaskCompletionSource();

            gameManager.Finish += (memoryGameResults) =>
            {
                finishCompletionSource.TrySetResult();  // Завершаем задачу
            };

            // Ожидаем завершения игры
            await finishCompletionSource.Task;

            // Скрываем UI после завершения игры
            miniGameUi.Hide();

            gameScript.SetValue(ScriptName, ScriptText);

            gameScript.Play();
        }
    }
}
