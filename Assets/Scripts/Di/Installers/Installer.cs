using System.ComponentModel;
using Games;
using Managers.MainScene;
using Zenject;

namespace Di.Installers
{
    public class Installer: MonoInstaller<Installer>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainScene>().AsSingle().NonLazy();
            Container.Bind<First>().AsSingle().NonLazy();
            Container.Bind<Second>().AsSingle().NonLazy();
            Container.Bind<Third>().AsSingle().NonLazy();

            Container.Bind<GameRunner>().AsSingle().NonLazy();
        }
    }
}