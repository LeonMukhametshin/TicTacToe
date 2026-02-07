using Leopotam.Ecs;
using UnityEngine;

namespace TicToe {
    public class InitializeFieldSystems : IEcsInitSystem
    {
        private Configuration m_configuration;
        private EcsWorld m_world;
        private GameState m_gameState;

        public void Init()
        {
            for(int x = 0; x < m_configuration.levelWidth; x++)
            {
                for(int y = 0; y < m_configuration.levelHeight; y++)
                {
                    var cellEntity = m_world.NewEntity();
                    cellEntity.Get<Cell>();
                    var position = new Vector2Int(x, y);
                    cellEntity.Get<Position>().value = position;

                    m_gameState.cells[position] = cellEntity;
                }
            }

            m_world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}