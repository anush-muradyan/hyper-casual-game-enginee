using System;
using System.Collections.Generic;
using Core.MVVM.GameView;
using Games;
using Games.SquareFall;

namespace Core.Context {
    public class ContextBuilder {
        private Dictionary<string, Func<GameView, IGamePlay, Context>> contextDictionary =
            new Dictionary<string, Func<GameView, IGamePlay, Context>>() {
                {"SquareFall", (view, play) => new SquareFallContext(view, play)}
            };

        public Context Build(string id, GameView gameView, IGamePlay gamePlay) {
            return contextDictionary[id].Invoke(gameView, gamePlay);
        }
    }

    public abstract class AbstractContext {
        public abstract void Subscribe();
        public abstract void UnSubscribe();
        public abstract void Start();
    }

    public abstract class Context : AbstractContext {
        protected readonly GameView gameView;
        private readonly IGamePlay gamePlay;

        protected Context(GameView gameView, IGamePlay gamePlay) {
            this.gameView = gameView;
            this.gamePlay = gamePlay;
        }

        public override void Start() {
            gamePlay.StartGame();
        }
    }

    public abstract class Context<TGame> : Context where TGame : IGamePlay {
        protected readonly TGame gameController;

        protected Context(GameView gameView, IGamePlay gamePlay)
            : base(gameView, gamePlay) {
            gameController = (TGame) gamePlay;
        }
    }

    public class SquareFallContext : Context<SquareFallGameController> {
        public SquareFallContext(GameView view, IGamePlay gameController)
            : base(view, gameController) {
        }

        public override void Subscribe() {
            gameController.OnGameScoreChange.AddListener(onGameScoreChange);
            gameView.ViewModel.Model.OnRestartGame.AddListener(restartGame);
        }

        private void onGameScoreChange(int score) {
            gameView.ViewModel.Model.Score = score;
        }

        public override void UnSubscribe() {
            gameController.OnGameScoreChange.RemoveListener(onGameScoreChange);
        }

        private void restartGame() {
            gameController.RestartGame();
        }

        private void closeGame() {
            gameController.Quit();
        }
    }
}