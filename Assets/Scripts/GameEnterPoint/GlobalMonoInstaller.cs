using Managers;
using UnityEngine;
using Zenject;

public class GlobalMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUIManager>().To<UIManager>().AsSingle().NonLazy();
    }
}