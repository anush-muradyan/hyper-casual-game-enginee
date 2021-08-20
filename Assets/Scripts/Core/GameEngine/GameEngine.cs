using System;
using System.Collections.Generic;
using System.Linq;
using Core.Game;
using GameStates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.GameEngine
{
    public class GameEngine : MonoBehaviour, IGameStart
    {
        [SerializeField] private Button startButton;
        public UnityEvent<GameInfo> OnGame = new UnityEvent<GameInfo>();
        private Dictionary<Type, List<IGameState>> gameStates;
        
        private void Start()
        {
            gameStates = new Dictionary<Type, List<IGameState>>();
            AddType<IGameStart>();
            
        }

        private void OnEnable()
        {
            startButton.onClick.AddListener(StartGame);
        }
        
        private void OnDisable()
        {
            startButton.onClick.AddListener(StartGame);
        }

        public void StartGame()
        {
            ResolveType<IGameStart>().ForEach(start => start.StartGame());
        }

        private void AddType<T>() where T : class
        {
            
        }

        private List<T> ResolveType<T>() where T : class
        {
            var type = typeof(T);
            if (!gameStates.ContainsKey(type))
            {
                Debug.LogError("CAN NOT FIND THAT TYPE!!!: " + type);
                return null;
            }

            return gameStates[type].Select(state => state as T).ToList();
        }
    }
}