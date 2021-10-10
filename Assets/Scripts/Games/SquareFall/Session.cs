using Core.GameStates;

namespace Games.SquareFall {
    public class Session {
        public GameState State;
        public int Score { get; set; }
      
        public Session() {
        }
    }
}