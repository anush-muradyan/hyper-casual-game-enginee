using Core;
using Core.View;
using UnityEngine;
using Zenject;

namespace Di.Installers
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField] private ViewManager viewManager;

        public override void InstallBindings()
        {
            Container.Bind<ViewFactory>().AsSingle().NonLazy();
            Container.Bind<IViewManager>().FromInstance(viewManager).AsSingle().NonLazy();
            // Container.Bind<GameRunner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Startup>().AsSingle().NonLazy();
        }
    }
}