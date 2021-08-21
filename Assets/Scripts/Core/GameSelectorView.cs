using System;
using System.Collections.Generic;
using Core.Data;
using Core.Data.Game;
using Core.Game;
using UnityEngine;
using Zenject;

namespace Core
{
    public interface IGameSelectorView : IDisposable
    {
        event Action<GameInfo> OnGameSelected;
    }

    public class GameSelectorView : MonoBehaviour, IGameSelectorView
    {
        [SerializeField] private GameItem gameItemPrefab;
        [SerializeField] private RectTransform container;
        private IDataLoader dataLoader;
        private List<GameItem> gameItems = new List<GameItem>();


        public event Action<GameInfo> OnGameSelected;

        [Inject]
        private void construct(IDataLoader dataLoader)
        {
            this.dataLoader = dataLoader;
        }

        private void Start()
        {
            loadGameInfos();
        }

        private void loadGameInfos()
        {
            var games = dataLoader.LoadGameInfos();
            if (games == null)
            {
                Debug.LogError("Error loading games.");
                return;
            }

            createGameInfos(games);
        }

        private void createGameInfos(GamesData games)
        {
            foreach (GameInfo game in games.Games)
            {

                createGameInfo(game);
            }
        }

        private void createGameInfo(GameInfo game)
        {
            IGameItem item = Instantiate(gameItemPrefab, container);
            gameItems.Add((GameItem) item);
            item.OnSelected += OnGameSelected;
            item.Setup(game);
        }

        public void Dispose()
        {
            foreach (var game in gameItems)
            {
                game.OnSelected -= OnGameSelected;
                Destroy(game);
            }
        }
    }
}