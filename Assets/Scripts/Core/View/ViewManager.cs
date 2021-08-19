using System.ComponentModel;
using Core.Game;
using UnityEngine;
using Zenject;

namespace Core.View
{
    public class ViewManager : MonoBehaviour, IViewManager
    {
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private string viewPath;
        private ViewFactory factory;
        

        [Inject]
        private void construct(ViewFactory factory)
        {
            this.factory = factory;
        }

        public void Startup()
        {
            showGameSelectorView();
        }

        private void showGameSelectorView()
        {
            IGameSelectorView view = factory.Create<GameSelectorView>(viewPath, viewContainer);
            view.OnGameSelected+=handleGameSelected;
        }

        private void handleGameSelected(GameInfo gameInfo)
        {
            Debug.LogError(gameInfo);
            Instantiate(Resources.Load("Prefabs/Games/" + gameInfo.Name),viewContainer);
            //gameEngine.OnGame.AddListener(gameInfo => new GameInfo(gameInfo.Name,gameInfo.Code));

        }
    }
}