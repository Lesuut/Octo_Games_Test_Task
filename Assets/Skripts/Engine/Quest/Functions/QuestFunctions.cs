using Naninovel;

namespace NaninovelQuest
{
    [ExpressionFunctions]
    public static class QuestFunctions
    {
        public static bool IsQuestCompleted(string KeyId)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var inventory = uiManager.GetUI<QuestUI>();
            return inventory.IsQuestCompleted(KeyId);
        }
    }
}
