using Leopotam.Ecs;

namespace TicToe
{
    internal class InitializeSliderEventSystem : IEcsInitSystem
    {
        private EcsWorld m_world;

        public void Init()
        {
            m_world.NewEntity().Get<OnSliderValueChangedEvent>();
        }
    }
}