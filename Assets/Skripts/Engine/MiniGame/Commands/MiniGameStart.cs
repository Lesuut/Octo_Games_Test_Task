using Naninovel;

namespace NaninovelMiniGame
{
    [CommandAlias("miniGameStart")]
    public class MiniGameStart : Command
    {
        [RequiredParameter]
        public StringParameter SettingId;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var questUI = uiManager.GetUI<MiniGameUI>();

            await questUI.StartMiniGame(SettingId);
        }
    }
}