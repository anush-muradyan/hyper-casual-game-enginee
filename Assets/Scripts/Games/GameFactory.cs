using System;
using DefaultNamespace.Games;
using Zenject;
using IFactory = Core.AbstractFactory.IFactory;
using Object = UnityEngine.Object;

namespace Games {
    public class GameFactory : IFactory {
        public class Factory : PlaceholderFactory<IGamePlay> {
        }

        private readonly DiContainer container;

        public GameFactory(DiContainer container) {
            this.container = container;
        }

        public IGamePlay Create<T>(string id) where T : IGamePlay {
            var gamePlay = container.Resolve<T>();
            if (gamePlay == null) {
                throw new Exception("Cant find game play with id: " + id);
            }

            return gamePlay;
        }

        public void Quit<T>(T item) where T :IFactory {
            Object.Destroy(item as Object);
        }
    }
}