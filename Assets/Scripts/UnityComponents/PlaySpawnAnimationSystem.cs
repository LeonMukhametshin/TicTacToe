using DG.Tweening;
using Leopotam.Ecs;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    internal class PlaySpawnAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<TakenRef, SpawnAnimationPending> m_filter;
        private AnimationConfiguration m_configuration;
        
        public void Run()
        {
            foreach(var index in m_filter)
            {
                var signView = m_filter.Get1(index).value;
                var transform = signView.transform;

                var startScale = transform.localScale;
                transform.localScale = m_configuration.startSize;
                transform
                    .DOScale(startScale, m_configuration.duration)
                    .SetEase(m_configuration.ease);

                m_filter.GetEntity(index).Del<SpawnAnimationPending>();
            }
        }
    }
}