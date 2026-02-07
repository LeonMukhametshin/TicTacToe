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
        private SceneData m_sceneData;

        public void Run()
        {
            foreach (var index in m_filter)
            {
                ref var ecsEntity = ref m_filter.GetEntity(index);

                ecsEntity.Get<Taken>().value = m_gameState.currentType;
                ecsEntity.Get<CheckWinEvent>();

                m_gameState.currentType = m_gameState.currentType == SignType.Cross
                    ? SignType.Ring
                    : SignType.Cross;

                m_sceneData.ui.gameHUD.SetTurn(m_gameState.currentType);
            }
        }
    }
}