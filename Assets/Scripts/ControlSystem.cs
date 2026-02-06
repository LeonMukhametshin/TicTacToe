using Leopotam.Ecs;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

namespace TicToe {
    internal class ControlSystem : IEcsRunSystem
    {
        private SceneData m_sceneData;

        public void Run()
        {
            if(Input.GetMouseButtonDown(0))
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