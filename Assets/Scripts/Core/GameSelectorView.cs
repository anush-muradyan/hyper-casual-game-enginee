using System;
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
        }
        
    }
}