using Controllers;
using UI;
using Managers;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class GlobalMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignalWithInterfaces<SetUnitCoverSignal>();
        
        Container.Bind(typeof(ISelectUnitManager),typeof(IInitializable)).To<SelectUnitManager>().AsSingle().NonLazy();
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle().NonLazy();
        Container.Bind<IUnitsManager>().To<UnitsManager>().AsSingle().NonLazy();
        Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
        Container.Bind<IUIManager>().To<UIManager>().AsSingle().NonLazy();
        
        Container.Bind<BattleSceneStateMachine<BattleStates>>().AsSingle().NonLazy();
        
        Container.Bind<SetupBattleState>().AsSingle().NonLazy();
        Container.Bind<ChoiceActionBattleState>().AsSingle().NonLazy();
        Container.Bind<ActionBattleState>().AsSingle().NonLazy();
        Container.Bind<ResultBattleState>().AsSingle().NonLazy();
        
        Container.Bind<SetupBattleStateController>().AsSingle().NonLazy();
        Container.Bind<ChoiceActionBattleStateController>().AsSingle().NonLazy();
    }
}