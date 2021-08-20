using System;
using Core.Data;
using Core.Data.Game;
using Core.Game;
using Core.View.Factory;
using UnityEngine;
using Zenject;

namespace Core
{
    public interface IGameSelectorView
    {
        event Action<GameInfo> OnGameSelected;
    }

    public class GameSelectorView : MonoBehaviour, IGameSelectorView
    {
        [SerializeField] private GameItem gameItemPrefab;
        [SerializeField] private RectTransform container;
        private IDataLoader dataLoader;

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
                Debug.LogError("Vay qu ara");
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
            item.OnSelected += OnGameSelected;
            item.Setup(game);
        }
    }
}