using Leopotam.Ecs;
using TicToe.Components;
using TicToe.Services;

namespace TicToe.UnityComponents
{
    internal class TimerFinishHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<TimerFinishEvent> m_filter;
        private EcsWorld m_world;
        private GameState m_gameState;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                var entity = m_filter.GetEntity(index);
                var winner = m_world.NewEntity();
                winner.Get<Winner>();
                winner.Get<Taken>().value = m_gameState.currentType;

                entity.Del<TimerFinishEvent>();
            }
        }
    }
}