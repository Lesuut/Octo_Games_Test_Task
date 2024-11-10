using Naninovel;

namespace NaninovelQuest
{
    [CommandAlias("questComplete")]
    public class QuestComplete : Command
    {
        [RequiredParameter]
        public StringParameter KeyId;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var questUI = uiManager.GetUI<QuestUI>();

            await questUI.CompleteQuest(KeyId);
        }
    }
}