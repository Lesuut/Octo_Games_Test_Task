using DTT.MinigameMemory;
using Naninovel;
using System;
using UnityEngine;

namespace NaninovelMiniGame
{
    [EditInProjectSettings]
    public class MiniGameConfiguration : Configuration
    {
        public const string DefaultPathPrefix = "Mini Game DTT";

        [Serializable]
        public struct MemoruGameSettingItem
        {
            public string ItemId;
            public MemoryGameSettings GameSettings;
        }

        [Tooltip("Put the MemoryGameSettings here")]
        public MemoruGameSettingItem[] memoruGameSettings;

        [Tooltip("Mini game object label in UI configuration")]
        [ResourcePopup(DefaultPathPrefix)]
        public string MiniGameUIItemID;
    }
}
