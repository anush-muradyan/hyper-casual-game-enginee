using Core.AbstractFactory;
using Core.Data;
using Core.MVVM.View;
using Games;
using Games.SquareFall;
using UnityEngine;
using Zenject;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;

#endif

namespace Core.MVVM.GameSelectorView {
    public class GameSelectorView : View<GameSelectorViewModel, GameSelectorModel>, IQuit {
        [SerializeField] private RectTransform container;
        [Inject] private GameFactory gameFactory;

        private void Start() {
            ViewModel.OnGameSelected += handleGameSelected;
            ViewModel.loadGameInfos(container);
        }

        private void handleGameSelected(GameInfo gameInfo) {
#if ENABLE_CLOUD_SERVICES_ANALYTICS
            Analytics.CustomEvent($"{gameInfo.Id}");
#endif

            transform.gameObject.SetActive(false);
            //var game = gameFactory.Create<SquareFallGameController>(gameInfo.Id);
            //context.QuitItem = game as IQuit;
        }

        public void Quit() {
            gameObject.SetActive(false);
        }
    }
}