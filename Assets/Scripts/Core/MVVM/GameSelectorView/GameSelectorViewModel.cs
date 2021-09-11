using System;
using System.Collections.Generic;
using Core.Convertor;
using Core.Data;
using Core.Data.Game;
using Core.Game;
using Core.MVVM.Command;
using Core.MVVM.Home;
using Core.MVVM.View;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Object = UnityEngine.Object;

namespace Core.MVVM.GameSelectorView {
    public class GameSelectorViewModel : IViewModel<GameSelectorModel> {
        public GameSelectorModel Model { get; set; }
        private IDataLoader dataLoader = new DataLoader(new JsonConvertor());

        public event Action<GameInfo> OnGameSelected;

        [Inject]
        private void construct(IDataLoader dataLoader) {
            Debug.Log("construct called.");
            this.dataLoader = dataLoader;
        }

        public ICommand<List<GameInfo>> LoadGameItemsCommand =>
            new LoadGameItemsCommand(list => Model.GameInfos = new ObservableList<GameInfo>(list));

        private UnityEvent<GamesData, RectTransform> onGameInfos = new UnityEvent<GamesData, RectTransform>();

      
        public void loadGameInfos(RectTransform container) {
            var games = dataLoader.LoadGameInfos();
            if (games == null) {
                Debug.LogError("Error loading games.");
                return;
            }

            createGameInfos(games, container);
            onGameInfos.AddListener(createGameInfos);
        }

        private void createGameInfos(GamesData games, RectTransform container) {
            Model.GameInfos = new List<GameInfo>();
            foreach (GameInfo game in games.Games) {
                createGameInfo(game, container);
            }
        }

        private void createGameInfo(GameInfo game, RectTransform container) {
            IGameItem item = Object.Instantiate(Resources.Load<GameItem>("Prefabs/GameItem"), container);
            Model.GameInfos.Add(game);
            item.OnSelected += OnGameSelected;
            item.Setup(game);
        }
    }
}