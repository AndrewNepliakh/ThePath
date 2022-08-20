using Managers;
using Zenject;

public class GlobalMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle().NonLazy();
        Container.Bind<IUnitsManager>().To<UnitsManager>().AsSingle().NonLazy();
        Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
        Container.Bind<IUIManager>().To<UIManager>().AsSingle().NonLazy();
       
    }
}