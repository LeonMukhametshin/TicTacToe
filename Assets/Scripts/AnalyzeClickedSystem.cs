using Leopotam.Ecs;

namespace TicToe
{
    public class AnalyzeClickedSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> m_filter;
        private GameState m_gameState;

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
            }
        }
    }
}