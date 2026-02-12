using Leopotam.Ecs;

namespace TicToe
{
    internal class InitializeSliderSystem : IEcsRunSystem
    {
        private MainMenuUI m_mainMenuUI;

        public void Run()
        {
            m_mainMenuUI.SetPlayerCountText(m_mainMenuUI.SlidetValue());
        }
    }
}