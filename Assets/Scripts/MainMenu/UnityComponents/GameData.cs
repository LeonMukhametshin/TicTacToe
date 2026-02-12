using System;
using UnityEngine;

namespace TicToe
{
    internal class GameData : MonoBehaviour
    {
        public static GameData instance;

        public int playerCount => m_playerCount;

        public int timeToMove => m_timeToMove;


        private int m_playerCount;
        private int m_timeToMove;

      
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

        public void SetPlayerCount(int count)
        {
            if (count <= 1)
            {
                throw new ArgumentException("Count can`t be one or less");
            }

            m_playerCount = count;
        }
           

        public void SetTimeToMove(int time)
        {
            if(time <= 0)
            {
                throw new ArgumentException("Time can`t be negative or zero");
            }

            m_timeToMove = time;
        }
    }
}