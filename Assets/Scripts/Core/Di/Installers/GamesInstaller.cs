using Core.Context;
using Core.InputHandler;
using Games;
using Games.SquareFall;
using UnityEngine;
using Zenject;

namespace Core.Di.Installers {
    public class GamesInstaller : MonoInstaller<GamesInstaller> {
        [SerializeField] private string gamesPath;

        public override void InstallBindings() {
            Container.BindGame<SquareFallGameController>(gamesPath, "SquareFall");
            Container.Bind<GameFactory>().AsSingle().NonLazy();
            Container.Bind<ContextBuilder>().AsSingle().NonLazy();
        }
    }

    public static class Extensions {
        public static void BindGame<T>(this DiContainer container, string basePath, string id) where T : IGamePlay {
            var path = basePath + $"/{id}";
            container.Bind<T>().WithId(id).FromComponentInNewPrefabResource(path).AsSingle();
        }
    }
}