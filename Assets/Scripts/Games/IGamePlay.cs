using Core.AbstractFactory;

namespace Games {
    public interface IGamePlay : IQuit {
        void StartGame();
        void RestartGame();
        
        
    }
}