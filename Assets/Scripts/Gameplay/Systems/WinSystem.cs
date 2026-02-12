using Leopotam.Ecs;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> m_filter;
        private GameplaySceneData m_sceneData;

        public void Run()
        {
            if(m_sceneData.ui.winScreen.gameObject.activeInHierarchy)
            {
                return;
            }

            foreach(var index in m_filter)
            {
                m_sceneData.ui.winScreen.Show(true);
                m_sceneData.ui.gameHUD.Show(false);
                m_sceneData.ui.winScreen.SetWinner(m_filter.Get2(index).data.name);

                m_filter.GetEntity(index).Get<Winner>();
            }
        }
    }
}