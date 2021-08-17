using System;
using Managers.MainScene;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Games
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private MainScene mainScene;
        [SerializeField] private Transform gameContainer;

        public UnityEvent<int> openGame = new UnityEvent<int>();

        private void OnEnable()
        {
            mainScene.a.AddListener(SetGame);
        }

        private void SetGame(GamesEnum game)
        {
            
            switch (game)
            {
                case GamesEnum.First:
                    Create<First>();
                    break;
                case GamesEnum.Second:
                    Create<Second>();
                    break;
                case GamesEnum.Third:
                    Create<Third>();
                    break;
                default:
                    Debug.LogError("We dont have that game!");
                    return;
            }
        }
        
        public TConcrete Create<TConcrete>() where TConcrete: Object,IGame
        {
            var prefabName = typeof(TConcrete).Name;
            var path = $"{"Prefabs"}/{prefabName}";
            var productPrefab = Resources.Load<TConcrete>(path);
            var product = Instantiate(productPrefab);
            return product;
        }
    }
}