using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace TicToe {
    internal class InitializeFieldSystems : IEcsInitSystem
    {
        private Configuration m_configuration;
        private EcsWorld m_world;

        public void Init()
        {
            for(int x = 0; x < m_configuration.levelWidth; x++)
            {
                for(int y = 0; y < m_configuration.levelHeight; y++)
                {
                    var cellEntity = m_world.NewEntity();
                    cellEntity.Get<Cell>();
                    cellEntity.Get<Position>().value = new Vector2Int(x,y);
                }
            }

            m_world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}