using Core.Context;
using Core.Data;
using Core.MVVM.GameSelectorView;
using Core.MVVM.GameView;
using Core.View.Factory;
using Games;

namespace Core.Startup {
    public class Navigator {
        private readonly ViewFactory viewFactory;
        private readonly GameFactory gameFactory;
        private readonly ContextBuilder contextBuilder;

        public Navigator(ViewFactory viewFactory, GameFactory gameFactory, ContextBuilder contextBuilder) {
            this.viewFactory = viewFactory;
            this.gameFactory = gameFactory;
            this.contextBuilder = contextBuilder;
        }

        public void Startup() {
            showGameSelector();
        }

        private void showGameSelector() {
            var view = viewFactory.Create<GameSelectorView>();
            view.Init(new GameSelectorModel());
            view.ViewModel.OnGameSelected += selectedGame;
            view.gameObject.SetActive(true);
        }

        private GameView showGameView() {
            var view = viewFactory.Create<GameView>();
            view.Init(new GameModel());
            view.gameObject.SetActive(true);
            return view;
        }

        private void selectedGame(GameInfo gameInfo) {
            // var squareFallGame = gameFactory.Create<SquareFallGameController>(gameInfo.Id);
            var game = gameFactory.CreateV2(gameInfo.Id);
            var gameView = showGameView();
            
            var context = contextBuilder.Build(gameInfo.Id, gameView, game);
            context.Subscribe();
            context.Start();
            
        }
    }
}