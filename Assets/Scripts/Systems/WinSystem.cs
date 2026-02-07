using Leopotam.Ecs;

namespace TicToe
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> m_filter;
        private SceneData m_sceneData;

        public void Run()
        {
            if(m_sceneData.ui.winScreen.gameObject.activeInHierarchy)
            {
                return;
            }

            foreach(var index in m_filter)
            {
                ref var winnerType = ref m_filter.Get2(index);

                m_sceneData.ui.winScreen.Show(true);
                m_sceneData.ui.winScreen.SetWinner(winnerType.value);

                m_filter.GetEntity(index).Get<Winner>();
            }
        }
    }
}