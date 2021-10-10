using Core.Startup;
using Core.View.Factory;
using UnityEngine;
using Zenject;

namespace Core.Di.Installers {
    public class UIInstaller : MonoInstaller<UIInstaller> {
        [SerializeField] private RectTransform viewContainer;

        public override void InstallBindings() {
            Container.Bind<ViewConfig>().FromInstance(new ViewConfig("Prefabs/Views", viewContainer)).AsSingle()
                .NonLazy();
            Container.Bind<ViewFactory>().AsSingle().NonLazy();
           
            Container.Bind<Navigator>().AsSingle().NonLazy();
        }
    }
}