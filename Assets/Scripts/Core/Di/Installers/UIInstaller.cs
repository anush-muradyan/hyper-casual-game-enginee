using Core.MVVM;
using Core.Startup;
using Core.View.Factory;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Zenject;
using Context = Core.Context.Context;

namespace Core.Di.Installers {
    public class UIInstaller : MonoInstaller<UIInstaller> {
        [SerializeField] private RectTransform viewContainer;

        public override void InstallBindings() {
            Container.Bind<ViewConfig>().FromInstance(new ViewConfig("Prefabs/Views", viewContainer)).AsSingle()
                .NonLazy();
            Container.Bind<ViewFactory>().AsSingle().NonLazy();
            Container.Bind<Context.Context>().AsSingle().NonLazy();
            Container.Bind<Navigator>().AsSingle().NonLazy();
        }
    }
}