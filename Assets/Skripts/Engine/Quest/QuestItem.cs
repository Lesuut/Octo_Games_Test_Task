using System;

namespace NaninovelQuest
{
    public class QuestItem
    {
        [Serializable]
        public struct State
        {
            public string KeyId;
            public string Content;
            public bool IsCompleted;
        }

        private State state;

        public string KeyId => state.KeyId;
        public string Content => state.Content;
        public bool IsCompleted => state.IsCompleted;

        public QuestItem(string keyId, string content, bool IsCompleted = false)
        {
            state = new State
            {
                KeyId = keyId,
                Content = content,
                IsCompleted = IsCompleted
            };
        }

        public void Complete()
        {
            state.IsCompleted = true;
        }

        public State GetState() { return state; }
    }
}
