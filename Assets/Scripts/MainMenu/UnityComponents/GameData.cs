using UnityEngine;

namespace TicToe
{
    internal class GameData : MonoBehaviour
    {
        public static GameData instance;

        private int m_playerCount;
        private int m_timeToMove;

        public int playerCount
        {
            get => m_playerCount;
            private set
            {
                if(value != m_playerCount)
                {
                    m_playerCount = value;
                }
            }
        }

        public int timeToMove
        {
            get => m_timeToMove;
            private set
            {
                if(value != m_timeToMove)
                {
                    m_timeToMove = value;
                }
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetPlayerCount(int count) =>
            playerCount = count;

        public void SetTimeToMove(int time) =>
            timeToMove = time;
    }
}