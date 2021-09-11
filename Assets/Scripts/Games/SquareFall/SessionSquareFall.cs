using Core.GameStates;

namespace Games.SquareFall {
    public class SessionSquareFall {
        public GameState State;
        public int Score { get; set; }

        public string StartMessage;

        public SessionSquareFall() {
        }
    }
}