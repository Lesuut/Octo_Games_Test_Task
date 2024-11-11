using DTT.MinigameMemory;
using Naninovel;
using NaninovelInventory;
using System;
using System.Linq;

namespace NaninovelMiniGame
{
    [InitializeAtRuntime]
    public class MiniGameManager : IEngineService<MiniGameConfiguration>
    {
        public MiniGameConfiguration Configuration { get; }

        public MiniGameManager(MiniGameConfiguration config)
        {
            Configuration = config;
        }

        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
            
        }

        public void DestroyService()
        {
            
        }

        public async UniTask<MemoryGameSettings> GetItemGameSettingsAsync(string itemId)
        {
            UnityEngine.Debug.Log("StartMiniGame!");
            var itemResource = await UniTask.FromResult(Configuration.memoruGameSettings.FirstOrDefault(item => (item.ItemId == itemId)).GameSettings);
            return itemResource;
        }
        public string GetMiniGameUIItemID() { return Configuration.MiniGameUIItemID; }
    }
}
