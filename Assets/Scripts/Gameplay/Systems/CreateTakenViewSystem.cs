using System;
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
                var takenType = m_filter.Get1(index).value;

                SignView signView = null;
                switch (takenType)
                {
                    case SignType.Cross:
                        signView = m_configuration.crossView;
                        break;
                    case SignType.Ring:
                        signView = m_configuration.righView;
                        break;
                    case SignType.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var instantice = UnityEngine.Object.Instantiate(signView, position, Quaternion.identity);
                var entity = m_filter.GetEntity(index);
                entity.Get<TakenRef>().value = instantice;
                entity.Get<SpawnAnimationPending>();
            }
        }
    }
}