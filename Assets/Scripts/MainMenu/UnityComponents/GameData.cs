using UnityEngine;

namespace TicToe
{
    internal class GameData : MonoBehaviour
    {
        public static GameData instance;
        private int m_plyaerCount;

        public int playerCount
        {
            get => m_plyaerCount;
            private set
            {
                if(value != m_plyaerCount)
                {
                    m_plyaerCount = value;
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
    }
}