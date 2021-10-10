using Core.Convertor;
using Core.Data;
using Core.InputHandler;
using Core.ObjectPooling;
using Games.SquareFall;
using ObjectPoolingV2.CorePooling.Generator;
using UnityEngine;
using Zenject;

namespace Core.Di.Installers {
    public class Installer : MonoInstaller<Installer> {
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private ScreenSize screenSize;
        [SerializeField] private GameInput gameInput;

        [SerializeField] private EnemyGenerator enemyGenerator;
        [SerializeField] private BonusItemGenerator bonusItemGenerator;

        public override void InstallBindings() {
            Container.Bind<IConvertor>().To<JsonConvertor>().AsSingle().NonLazy();
            Container.Bind<IDataLoader>().To<DataLoader>().AsSingle().NonLazy();

            Container.Bind<Session>().AsSingle().NonLazy();

            Container.Bind<ScreenSize>().FromInstance(screenSize).AsSingle().NonLazy();
            Container.Bind<PoolManager>().FromInstance(poolManager).AsSingle().NonLazy();

            Container.Bind<EnemyGenerator>().FromInstance(enemyGenerator).AsSingle().NonLazy();
            Container.Bind<BonusItemGenerator>().FromInstance(bonusItemGenerator).AsSingle().NonLazy();
            gameInput.BindInput(Container);
            Container.BindInterfacesTo<Startup.Startup>().AsSingle().NonLazy();
        }
        
    }
}