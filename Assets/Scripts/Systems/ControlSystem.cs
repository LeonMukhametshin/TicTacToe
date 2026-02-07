using UnityEngine;
using Leopotam.Ecs;
using TicToe.UnityComponents;

namespace TicToe.Systems
{ 
    public class ControlSystem : IEcsRunSystem
    {
        private SceneData m_sceneData;

        public void Run()
        {
            if (m_sceneData.ui.winScreen.gameObject.activeInHierarchy ||
                m_sceneData.ui.loseScreen.gameObject.activeInHierarchy)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                var camera = m_sceneData.Camera;
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();
                    if(cellView)
                    {
                        cellView.entity.Get<Clicked>();
                    }
                }
            }
        }
    }
}