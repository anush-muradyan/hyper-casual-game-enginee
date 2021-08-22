using Core.Data;
using Core.GameCore;
using Core.View.Factory;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.View
{
    public class GameSelectorViewModel:MonoBehaviour,INotify
    {
        private ViewFactory factory;
        private GameEngine gameEngine;

        public UnityEvent<GameInfo> OnGame = new UnityEvent<GameInfo>();
        private IGameSelectorView view;


        [Inject]
        public void construct(ViewFactory factory,GameEngine gameEngine)
        {
            this.factory = factory;
            this.gameEngine = gameEngine;
        }
        private void OnDisable()
        {
            view.OnGameSelected -= handleGameSelected;
            OnGame.RemoveListener(gameEngine.InstantiateGame);
        }
         public void showGameSelectorView()
        {
            view = factory.Create<GameSelectorView>();
            view.OnGameSelected += handleGameSelected;
        }

        public void handleGameSelected(GameInfo gameInfo)
        {
            Debug.LogError(gameInfo);
            GameSelected(gameInfo);
        }

        public void GameSelected(GameInfo gameInfo)
        {
            OnGame.AddListener(gameEngine.InstantiateGame);
            OnGame?.Invoke(gameInfo);
            
            /*view.OnGameSelected -= handleGameSelected;
            OnGame.RemoveListener(gameEngine.InstantiateGame)*/;
        }

        public void Startup()
        {
            throw new System.NotImplementedException();
        }

        public ViewConfig GetConfig()
        {
            throw new System.NotImplementedException();
        }
    }
}