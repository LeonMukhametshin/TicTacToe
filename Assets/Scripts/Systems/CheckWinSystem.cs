using Leopotam.Ecs;
using TicToe.Services;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> m_filter;
        private GameState m_gameState;
        private Configuration m_configuration;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                ref var position = ref m_filter.Get1(index);
                ref var type = ref m_filter.Get2(index);

                var chainLenght = m_gameState.cells.GetLongestChain(position.value);
                if(chainLenght >= m_configuration.chainLenght)
                {
                    m_filter.GetEntity(index).Get<Winner>();
                }
            }
        }
    }
}