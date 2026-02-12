using UnityEngine;
using Leopotam.Ecs;
using TicToe.Components;
using TicToe.UnityComponents;

namespace TicToe.Systems
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> m_filter;
        private Configuration m_configuration;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                var cellTransfrom = m_filter.Get2(index).value.transform;
                var position = cellTransfrom.position + cellTransfrom.localScale / 2f;
                var takenID = m_filter.Get1(index).data.id;

                SignView signView = m_configuration.signViews.GetSign(takenID);

                var instantice = UnityEngine.Object.Instantiate(signView, position, Quaternion.identity);
                var entity = m_filter.GetEntity(index);
                entity.Get<TakenRef>().value = instantice;
                entity.Get<SpawnAnimationPending>();
                entity.Get<SignData>().name = m_configuration.readOnlySignList.GetSign(takenID).name;
            }
        }
    }
}