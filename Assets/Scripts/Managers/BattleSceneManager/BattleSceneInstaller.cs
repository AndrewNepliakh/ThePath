using Controllers;
using Managers;
using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private BattleSceneManager _battleSceneManager;
    public override void InstallBindings()
    {
        Container.Bind<BattleSceneManager>().FromInstance(_battleSceneManager).AsSingle().NonLazy();
        Container.Bind<StateMachine<BattleStates>>().AsSingle().NonLazy();
        
        Container.Bind<SetupBattleState>().AsSingle().NonLazy();
        Container.Bind<ChoiceActionBattleState>().AsSingle().NonLazy();
        Container.Bind<ActionBattleState>().AsSingle().NonLazy();
        Container.Bind<ResultBattleState>().AsSingle().NonLazy();
        
        Container.Bind<SetupBattleStateController>().AsSingle().NonLazy();
        Container.Bind<ChoiceActionBattleStateController>().AsSingle().NonLazy();
        
    }
}