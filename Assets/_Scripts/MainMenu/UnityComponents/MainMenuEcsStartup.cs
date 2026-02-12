using Leopotam.Ecs;
using UnityEngine;

namespace TicToe 
{
    sealed class MainMenuEcsStartup : MonoBehaviour 
    {
        public static EcsWorld world;
        private EcsSystems m_systems;

        public MainMenuUI mainMenuUI;

        private void Start () 
        {
            world = new EcsWorld();
            m_systems = new EcsSystems(world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(m_systems);
#endif
            m_systems
                .Add(new UpdateGameSettingsSystem())

                .OneFrame<PlayerCountChangedEvent>()
                .OneFrame<TimeToMoveChangedEvent>()

                .Init();
        }

        private void Update() 
        {
            m_systems?.Run();
        }

        private void OnDestroy() 
        {
            if (m_systems != null) 
            {
                m_systems.Destroy();
                m_systems = null;
                world.Destroy();
                world = null;
            }
        }
    }
}