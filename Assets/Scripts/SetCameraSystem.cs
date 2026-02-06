using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> m_filter;
        private SceneData m_sceneData;
        private Configuration m_configuration;

        public void Run()
        {
            if(m_filter.IsEmpty())
            {
                return;
            }

            var height = m_configuration.levelHeight;

            var camera = m_sceneData.Camera;
            camera.orthographic = true;
            camera.orthographicSize = height / 2f + (height - 1) * m_configuration.offset.y / 2;

            m_sceneData.cameraTransfrom.position = new Vector3(
                m_configuration.levelWidth / 2f + (m_configuration.levelWidth - 1) * m_configuration.offset.x / 2, 
                height / 2f + (height - 1) * m_configuration.offset.y / 2);
        }
    }
}