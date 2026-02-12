using Leopotam.Ecs;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    internal class InitializerTimerSystem : IEcsInitSystem
    {
        private EcsWorld m_world;

        public void Init()
        {
            m_world.NewEntity().Get<Timer>().value = GameData.instance.timeToMove;
        }
    }
}