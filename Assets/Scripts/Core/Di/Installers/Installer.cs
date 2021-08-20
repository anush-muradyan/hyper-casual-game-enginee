using Core.Convertor;
using Core.Data;
using Core.View;
using Core.View.Factory;
using UnityEngine;
using Zenject;

namespace Core.Di.Installers
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField] private ViewManager viewManager;

        public override void InstallBindings()
        {
            Container.Bind<IConvertor>().To<JsonConvertor>().AsSingle().NonLazy();
            Container.Bind<IDataLoader>().To<DataLoader>().AsSingle().NonLazy();

            Container.Bind<ViewFactory>().AsSingle().WithArguments(viewManager.GetConfig()).NonLazy();
            Container.Bind<IViewManager<ViewConfig>>().FromInstance(viewManager).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Startup>().AsSingle().NonLazy();
        }
    }
}