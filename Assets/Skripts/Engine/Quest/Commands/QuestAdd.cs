using Naninovel;

namespace NaninovelQuest
{
    [CommandAlias("questAdd")]
    public class QuestAdd : Command
    {
        [RequiredParameter]
        public StringParameter KeyId;
        [RequiredParameter]
        public StringParameter Content;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var questUI = uiManager.GetUI<QuestUI>();

            await questUI.AddQuest(new QuestItem(KeyId, Content));
        }
    }
}
