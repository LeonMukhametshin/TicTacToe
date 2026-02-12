using Leopotam.Ecs;
using TicToe.Services;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class AnalyzeClickedSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> m_filter;
        private GameState m_gameState;
        private GameplaySceneData m_sceneData;

        public void Run()
        {
            foreach (var index in m_filter)
            {
                ref var ecsEntity = ref m_filter.GetEntity(index);

                ecsEntity.Get<Taken>().value = m_gameState.currentType;
                ecsEntity.Get<CheckWinEvent>();

                int indexNewSign = (int)m_gameState.currentType + 1;

                m_gameState.currentType = indexNewSign < GameData.instance.playerCount
                    ? (SignType)indexNewSign
                    : (SignType)0;

                m_sceneData.ui.gameHUD.SetTurn(m_gameState.currentType);
            }
        }
    }
}