using System;
using Core.MVVM.Command;
using Core.MVVM.View;

namespace Core.MVVM.GameView {
    public class GameViewModel : IViewModel<GameModel> {
        public GameModel Model { get; set; }

        public ICommand RestartGameCommand =>
            new RestartGameCommand(()=>Model.OnRestartGame?.Invoke());
    }

    public class RestartGameCommand : ICommand {
        private Action executor;

        public RestartGameCommand(Action executor) {
            this.executor = executor;
        }

        public void Execute() {
            executor?.Invoke();
        }
    }
}