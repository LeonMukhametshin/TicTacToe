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
                m_mainMenuUI.playerCountSlider.SetText(m_mainMenuUI.playerCountSlider.GetSiderValue());
                m_mainMenuUI.timeToMoveSlider.SetText(m_mainMenuUI.timeToMoveSlider.GetSiderValue());

                GameData.instance.SetPlayerCount(m_mainMenuUI.playerCountSlider.GetSiderValue());
                GameData.instance.SetTimeToMove(m_mainMenuUI.timeToMoveSlider.GetSiderValue());
            }
        }
    }
}