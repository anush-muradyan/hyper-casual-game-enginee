using Games;
using Games.SquareFall;
using UnityEngine;
using Zenject;

namespace Core.Di.Installers {
    public class GamesInstaller : MonoInstaller<GamesInstaller> {
        [SerializeField] private string gamesPath;

        public override void InstallBindings() {
            Container.BindGame(gamesPath + "SquareFall");
            Container.Bind<GameFactory>().AsSingle().NonLazy();
        }
    }

    public static class Extensions {
        public static void BindGame(this DiContainer container, string path) {
            container.Bind<SquareFallGameController>().FromComponentInNewPrefabResource(path).AsSingle();
        }
    }
}