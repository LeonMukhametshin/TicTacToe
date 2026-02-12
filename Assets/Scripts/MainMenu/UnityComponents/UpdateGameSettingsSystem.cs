using Leopotam.Ecs;

namespace TicToe
{
    internal class UpdateGameSettingsSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerCountChangedEvent> m_playerCountFilter;
        private EcsFilter<TimeToMoveChangedEvent> m_timeToMoveFilter;

        public void Run()
        {
            foreach(var inxed in m_playerCountFilter)
            {
                ref var entity = ref m_playerCountFilter.Get1(inxed);
                GameData.instance.SetPlayerCount(entity.value);
            }

            foreach(var inxed in m_timeToMoveFilter)
            {
                ref var entity = ref m_timeToMoveFilter.Get1(inxed);
                GameData.instance.SetTimeToMove(entity.value);
            }
        }
    }
}