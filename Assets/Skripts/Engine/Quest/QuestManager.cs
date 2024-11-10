using Naninovel;

namespace NaninovelQuest
{
    [InitializeAtRuntime]
    [Naninovel.Commands.Goto.DontReset]
    public class QuestManager : IEngineService
    {
        public QuestManager()
        {

        }

        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
            var quest = Engine.GetService<IUIManager>().GetUI<QuestUI>();
            if (ObjectUtils.IsValid(quest))
                quest.RemoveAllQuests();
        }

        public void DestroyService()
        {
            // Остановка сервиса и разгрузка всех используемых ресурсов.
        }
    }
}