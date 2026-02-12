using Leopotam.Ecs;

namespace TicToe
{
    internal class SliderEventHadlerEvent : IEcsRunSystem
    {
        private EcsFilter<OnSliderValueChangedEvent> m_filter;
        private MainMenuUI m_mainMenuUI;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                m_mainMenuUI.SetPlayerCountText(m_mainMenuUI.GetSliderValue());
                GameData.instance.SetPlayerCount(m_mainMenuUI.GetSliderValue());
            }
        }
    }
}