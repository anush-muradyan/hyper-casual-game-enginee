using System;
using System.Collections.Generic;
using Core.AbstractFactory;
using Games.SquareFall;
using Zenject;
using Object = UnityEngine.Object;

namespace Games {
    public class GameFactory {
        public static Dictionary<string, Type> Games = new Dictionary<string, Type>() {
            {"SquareFall", typeof(SquareFallGameController)}
        };
        public class Factory : PlaceholderFactory<IGamePlay> {
        }

        private readonly DiContainer container;

        public GameFactory(DiContainer container) {
            this.container = container;
        }

        public T Create<T>(string id) where T : IGamePlay {
            var gamePlay = container.Resolve<T>();
            if (gamePlay == null) {
                throw new Exception("Cant find game play with id: " + id);
            }

            return gamePlay;
        }

        public IGamePlay CreateV2(string id) {
            var gamePlay = container.ResolveId(Games[id], id) as IGamePlay;
            if (gamePlay == null) {
                throw new Exception("Cant find game play with id: " + id);
            }

            return gamePlay;
        }
    }
}