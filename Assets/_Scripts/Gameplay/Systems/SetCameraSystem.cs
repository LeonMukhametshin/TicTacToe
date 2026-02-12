using UnityEngine;
using Leopotam.Ecs;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> m_filter;
        private GameplaySceneData m_sceneData;
        private Configuration m_configuration;

        public void Run()
        {
            if(m_filter.IsEmpty())
            {
                return;
            }

            var height = m_configuration.levelHeight;
            var width = m_configuration.levelWidth;
            var boardHeight = height + (height - 1) * m_configuration.offset.y;
            var boardWidth = width + (width - 1) * m_configuration.offset.x;
            var hudSpace = Mathf.Max(1f, boardHeight * 0.2f);
            var totalHeight = boardHeight + hudSpace;

            var camera = m_sceneData.Camera;
            camera.orthographic = true;
            camera.orthographicSize = totalHeight / 2f;

            m_sceneData.cameraTransfrom.position = new Vector3(
                boardWidth / 2f,
                boardHeight / 2f + hudSpace / 2f);
        }
    }
}