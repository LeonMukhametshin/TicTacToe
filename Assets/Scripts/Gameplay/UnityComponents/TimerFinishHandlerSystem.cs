using Leopotam.Ecs;
using System;
using TicToe.Components;
using TicToe.Services;
using UnityEngine;

namespace TicToe.UnityComponents
{
    internal class TimerFinishHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<TimerFinishEvent> m_filter;
        private EcsWorld m_world;
        private GameState m_gameState;
        private Configuration m_configuration;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                Debug.Log("TImer fineshed;");
                var entity = m_filter.GetEntity(index);
                var winner = m_world.NewEntity();
                winner.Get<Winner>();

                int previousSingIndex = Convert.ToInt32(m_gameState.currentSing.id) - 1;

                if (previousSingIndex < 0)
                {
                    previousSingIndex = GameData.instance.playerCount - 1;
                }

                winner.Get<Taken>().data = m_configuration.readOnlySignList.GetSign(previousSingIndex.ToString()).signData;

                entity.Del<TimerFinishEvent>();
            }
        }
    }
}