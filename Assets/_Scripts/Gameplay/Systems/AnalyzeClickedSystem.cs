using System;
using Leopotam.Ecs;
using TicToe.Services;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class AnalyzeClickedSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> m_filter;
        private GameplaySceneData m_sceneData;
        private Configuration m_configuration;
        private GameState m_gameState;
       
        public void Run()
        {
            foreach (var index in m_filter)
            {
                ref var ecsEntity = ref m_filter.GetEntity(index);

                ecsEntity.Get<Taken>().data = m_gameState.currentSign;
                ecsEntity.Get<CheckWinEvent>();

                int indexNewSign = Convert.ToInt32(m_gameState.currentSign.id) + 1;

                if(indexNewSign >= GameData.instance.playerCount)
                {
                    indexNewSign = 0;
                }

                m_gameState.currentSign = m_configuration.readOnlySignList
                    .GetSign(indexNewSign.ToString()).signData;

                m_sceneData.ui.gameHUD.SetTurn(m_gameState.currentSign.name);
            }
        }
    }
}