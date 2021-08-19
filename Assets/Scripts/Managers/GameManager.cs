using System;
using System.Collections.Generic;
using System.Linq;
using GameStates;
using UnityEngine;
using Utils = Tools.Utils;

namespace Managers
{
    public class GameManager:MonoBehaviour
    {
        private Dictionary<Type, List<IGameState>> gameStates;
        
        private void Awake()
        {
            compose();
        }
        
        private void compose()
        {
            gameStates = new Dictionary<Type, List<IGameState>>();
            AddType<IGameStart>();
            AddType<IGamePause>();
            AddType<IGameResume>();
            AddType<IGameLoose>();
            AddType<IGameRestart>();
            AddType<IGameWin>();
        }
        
        private void AddType<T>() where T:class
        {
            gameStates.Add(typeof(T),Utils.GetInterfaces<T,IGameState>());
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

        public void StartGame()
        {
            
            ResolveType<IGameStart>().ForEach(start => start.StartGame());
        }
        
        public void PauseGame()
        {
            ResolveType<IGamePause>().ForEach(pause => pause.PauseGame());
        }
        
        public void ResumeGame()
        {
            ResolveType<IGameResume>().ForEach(resume => resume.ResumeGame());
        }
        
        public void RestartGame()
        {
            ResolveType<IGameRestart>().ForEach(restart => restart.RestartGame());
        }
        
        public void LooseGame()
        {
            ResolveType<IGameLoose>().ForEach(looseGame => looseGame.LooseGame());
        }
        
        public void WinGame()
        {
            ResolveType<IGameWin>().ForEach(win => win.WinGame());
        }
        
    }
}