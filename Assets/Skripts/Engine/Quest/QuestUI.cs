using System;
using System.Collections.Generic;
using Naninovel;
using UnityEngine;
using UnityEngine.UI;
using Naninovel.UI;
using System.Linq;

namespace NaninovelQuest
{
    public class QuestUI : CustomUI
    {
        [Serializable]
        private new class GameState
        {
            public GameState() { }

            public GameState(List<QuestItem> questItems)
            {
                Quests = questItems.Select(item => item.GetState()).ToList();
            }

            public List<QuestItem.State> Quests;
        }

        [SerializeField] private Text questTextContent;
        [Space]
        [SerializeField] private Color newQuestColor;
        [SerializeField] private Color questCompletedColor;
        [Space]
        [Range(0,10)]
        [SerializeField] private int showQuestHistoryCount = 1;

        private IStateManager stateManager;
        private QuestManager questManager;

        private List<QuestItem> questItems;

        public async UniTask AddQuest(QuestItem questItem)
        {
            questItems.Add(questItem);
            await UpdateQuestUIAsync();
        }

        public bool IsQuestCompleted(string keyId)
        {
            return questItems.Any(quest => quest.KeyId == keyId && quest.IsCompleted);
        }

        public async UniTask CompleteQuest(string keyId)
        {

            var quest = questItems.FirstOrDefault(quest => quest.KeyId == keyId);
            
            quest.Complete();

            await UpdateQuestUIAsync();
        }

        private async UniTask UpdateQuestUIAsync()
        {
            // Сортируем квесты: сначала активные, затем завершенные
            var activeQuests = questItems.Where(q => !q.IsCompleted).ToList();

            // Сортируем завершенные квесты в обратном порядке и ограничиваем их количество
            var completedQuests = questItems
                .Where(q => q.IsCompleted)
                .Reverse() // Переворачиваем, чтобы последние выполненные шли первыми
                .Take(showQuestHistoryCount)
                .ToList();

            // Формируем строку с отображаемыми квестами
            var activeQuestText = string.Join("\n", activeQuests.Select(q =>
                $"<color=#{ColorUtility.ToHtmlStringRGB(newQuestColor)}>* {q.Content}</color>"));

            var completedQuestText = string.Join("\n", completedQuests.Select(q =>
                $"<color=#{ColorUtility.ToHtmlStringRGB(questCompletedColor)}>{q.Content}</color>"));

            // Если оба текста не пустые, добавляем между ними перенос строки
            string finalText = activeQuestText;
            if (!string.IsNullOrEmpty(activeQuestText) && !string.IsNullOrEmpty(completedQuestText))
                finalText += "\n";

            // Добавляем текст завершенных квестов
            finalText += completedQuestText;

            // Обновляем текст UI
            questTextContent.text = finalText;

            // Выполнение асинхронных действий перед завершением обновления UI (при необходимости)
            await UniTask.Yield();
        }

        protected override void Awake()
        {
            base.Awake();

            questItems = new List<QuestItem>();

            questManager = Engine.GetService<QuestManager>();
            stateManager = Engine.GetService<IStateManager>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            stateManager.AddOnGameSerializeTask(SerializeState);
            stateManager.AddOnGameDeserializeTask(DeserializeState);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            stateManager.RemoveOnGameSerializeTask(SerializeState);
            stateManager.RemoveOnGameDeserializeTask(DeserializeState);
        }

        protected override void SerializeState(GameStateMap stateMap)
        {
            base.SerializeState(stateMap);

            var state = new GameState(questItems);

            stateMap.SetState(state);
        }

        protected override async UniTask DeserializeState(GameStateMap stateMap)
        {
            await base.DeserializeState(stateMap);

            var state = stateMap.GetState<GameState>();

            foreach (var item in state.Quests)
            {
                Debug.Log($"{item.IsCompleted}");
            }

            questItems = state.Quests.Select(item => new QuestItem(item.KeyId, item.Content, item.IsCompleted)).ToList();

            await UpdateQuestUIAsync();
        }
    }
}
