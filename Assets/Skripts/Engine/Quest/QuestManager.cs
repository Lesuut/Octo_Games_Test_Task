using UnityEngine;
using Naninovel;

namespace NaninovelQuest
{
    [InitializeAtRuntime]
    [Naninovel.Commands.Goto.DontReset]
    public class QuestManager : IEngineService
    {
        public QuestManager()
        {
            Debug.Log("QuestManager!");
        }

        public UniTask InitializeServiceAsync()
        {
            Debug.Log("QuestManager InitializeServiceAsync");

            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
            // Сброс состояния сервиса.
        }

        public void DestroyService()
        {
            // Остановка сервиса и разгрузка всех используемых ресурсов.
        }
    }
}