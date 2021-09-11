using Core.Data;
using Core.MVVM.View;
using Games;
using Games.SquareFall;
using UnityEngine;
using Zenject;
using IFactory = Core.AbstractFactory.IFactory;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;

#endif

namespace Core.MVVM.GameSelectorView {
    public class GameSelectorView : View<GameSelectorViewModel, GameSelectorModel> {
        [SerializeField] private RectTransform container;
        [Inject] private GameFactory gameFactory;
        [Inject] private Context.Context context;

        private void Start() {
            ViewModel.OnGameSelected += handleGameSelected;
            ViewModel.loadGameInfos(container);
        }

        private void handleGameSelected(GameInfo gameInfo) {
#if ENABLE_CLOUD_SERVICES_ANALYTICS
            Analytics.CustomEvent($"{gameInfo.Id}");
#endif
            transform.gameObject.SetActive(false);
            var game = gameFactory.Create<SquareFallGameController>(gameInfo.Id);
            context.Factory = game as IFactory;
        }
    }
}