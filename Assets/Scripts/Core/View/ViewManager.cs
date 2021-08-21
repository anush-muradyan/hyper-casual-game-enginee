using Core.Data;
using Core.GameCore;
using Core.View.Factory;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.View
{
    public class ViewManager : MonoBehaviour, IViewManager<ViewConfig>,INotify
    {
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private string viewPath;
        
        private ViewFactory factory;
        private GameEngine gameEngine;

        public UnityEvent<GameInfo> OnGame = new UnityEvent<GameInfo>();
        private IGameSelectorView view;
        
        [Inject]
        private void construct(ViewFactory factory,GameEngine gameEngine)
        {
            this.factory = factory;
            this.gameEngine = gameEngine;
        }

        public void Startup()
        {
            showGameSelectorView();
        }

        private void OnDisable()
        {
            view.OnGameSelected -= handleGameSelected;
            OnGame.RemoveListener(gameEngine.InstantiateGame);
        }

        public ViewConfig GetConfig()
        {
            return new ViewConfig(viewPath, viewContainer);
        }

        private void showGameSelectorView()
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
    }
}