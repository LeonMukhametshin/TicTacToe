using Leopotam.Ecs;
using UnityEngine;

namespace TicToe 
{
    sealed class MainMenuEcsStartup : MonoBehaviour 
    {
        private EcsWorld m_world;
        private EcsSystems m_systems;

        public MainMenuUI mainMenuUI;

        private void Start () 
        {
            m_world = new EcsWorld();
            m_systems = new EcsSystems(m_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(m_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(m_systems);
#endif
            m_systems
                .Add(new UpdateGameSettingsSystem())
                
                .OneFrame<PlayerCountChangedEvent>()
                .OneFrame<TimeToMoveChangedEvent>()

                .Inject(mainMenuUI)

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
                m_world.Destroy();
                m_world = null;
            }
        }
    }
}