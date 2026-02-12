using Leopotam.Ecs;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    internal class InitializerTimerSystem : IEcsInitSystem
    {
        private Configuration m_configuration;
        private EcsWorld m_world;

        public void Init()
        {
            m_world.NewEntity().Get<Timer>().value = m_configuration.timeToMove;
        }
    }
}