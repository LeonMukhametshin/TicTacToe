using Leopotam.Ecs;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    internal class UpdateTimerViewSystem : IEcsRunSystem
    {
        private EcsFilter<Timer> m_filter;
        private SceneData m_sceneData;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                m_sceneData.ui.gameHUD.UpdateTextTimer(m_filter.Get1(index).value);
            }
        }
    }
}