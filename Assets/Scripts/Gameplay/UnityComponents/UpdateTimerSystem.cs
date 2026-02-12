using Leopotam.Ecs;
using TicToe.Components;
using UnityEngine;

namespace TicToe.UnityComponents
{
    internal class UpdateTimerSystem : IEcsRunSystem
    {
        private EcsFilter<Timer> m_filter;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                ref var timer = ref m_filter.Get1(index);
                var entity = m_filter.GetEntity(index);

                timer.value -= Time.deltaTime;
                Debug.Log(timer.value);

                if(timer.value <= 0)
                {
                    entity.Get<TimerFinishEvent>();
                    entity.Del<Timer>();
                }
            }
        }
    }
}