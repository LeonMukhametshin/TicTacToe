using Leopotam.Ecs;
using System;
using UnityEngine;

namespace TicToe
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> m_filter;
        private Configuration m_configuration;

        public void Run()
        {
            foreach(var index in m_filter)
            {
                var position = m_filter.Get2(index).value.transform.position;
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
                m_filter.GetEntity(index).Get<TakenRef>().value = instantice;
            }
        }
    }
}