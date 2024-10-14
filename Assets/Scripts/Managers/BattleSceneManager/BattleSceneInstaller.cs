using Zenject;
using Controllers;
using UnityEngine;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private BattleSceneManager _battleSceneManager;
    
    public override void InstallBindings()
    {
        Container.Bind<BattleSceneManager>().FromInstance(_battleSceneManager).AsSingle().NonLazy();
    }
}