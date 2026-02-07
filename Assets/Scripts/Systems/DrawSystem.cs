using Leopotam.Ecs;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken> m_freeCells;
        private EcsFilter<Winner> m_winner;
        private SceneData m_sceneData;

        public void Run()
        {
            if(m_freeCells.IsEmpty() && m_winner.IsEmpty())
            {
                m_sceneData.ui.loseScreen.Show(true);
            }
        }
    }
}