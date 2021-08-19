using System;
using System.Linq;
using Core.Game;
using UnityEngine;

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

        public event Action<GameInfo> OnGameSelected;

        private void Start()
        {
            // foreach (GameInfo gameInfo in Enumerable.Range(0, 4)
            //     .Select(i => new GameInfo(i.ToString(), i.ToString())))
            // {
            //     IGameItem gameItem = Instantiate(gameItemPrefab, container);
            //     gameItem.OnSelected += OnGameSelected;
            //     gameItem.Setup(gameInfo);

            // }

            foreach (var i in Resources.LoadAll("Prefabs/Games"))
            {
                GameInfo gameInfo = new GameInfo(i.name, i.ToString());
                IGameItem gameItem = Instantiate(gameItemPrefab, container);
                gameItem.OnSelected += OnGameSelected;
                gameItem.Setup(gameInfo);
            }
        }
        
    }
}