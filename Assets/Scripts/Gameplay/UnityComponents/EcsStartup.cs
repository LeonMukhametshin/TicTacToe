using Leopotam.Ecs;
using TicToe.Components;
using TicToe.Services;
using TicToe.Systems;
using UnityEngine;

namespace TicToe.UnityComponents
{
    sealed class EcsStartup : MonoBehaviour 
    {
        private EcsWorld m_world;
        private EcsSystems m_systems;

        public Configuration configuration;
        public AnimationConfiguration animationConfiguration;
        public GameplaySceneData sceneData;

        private void Start() 
        {
            m_world = new EcsWorld();
            m_systems = new EcsSystems(m_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(m_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(m_systems);
#endif
            var gameState = new GameState();
            sceneData.ui.gameHUD.SetTurn(gameState.currentType);

            m_systems

                .Add(new InitializeFieldSystem())
                .Add(new InitializerTimerSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControlSystem())
                .Add(new UpdateTimerSystem())
                .Add(new TimerFinishHandlerSystem())
                .Add(new UpdateTimerViewSystem())
                .Add(new AnalyzeClickedSystem())
                .Add(new CreateTakenViewSystem())
                .Add(new PlaySpawnAnimationSystem())
                .Add(new CheckWinSystem())
                .Add(new WinSystem())
                .Add(new DrawSystem())

                .OneFrame<UpdateCameraEvent>()
                .OneFrame<Clicked>()
                .OneFrame<CheckWinEvent>()

                .Inject(configuration)
                .Inject(animationConfiguration)
                .Inject(sceneData)
                .Inject(gameState)

                .Init ();
        }

        private void Update() 
        {
            m_systems?.Run ();
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