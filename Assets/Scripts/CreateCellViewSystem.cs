using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> m_filter;
        private Configuration m_configuration;

        public void Run()
        {
            foreach (var index in m_filter)
            {
                ref var position = ref m_filter.Get2(index);

                var cellView = Object.Instantiate(m_configuration.cellView);

                cellView.transform.position = new Vector3(position.value.x + m_configuration.offset.x * position.value.x, 
                    position.value.y + m_configuration.offset.y * position.value.y);

                cellView.entity = m_filter.GetEntity(index);

                m_filter.GetEntity(index).Get<CellViewRef>().value = cellView;
            }
        }
    }
}