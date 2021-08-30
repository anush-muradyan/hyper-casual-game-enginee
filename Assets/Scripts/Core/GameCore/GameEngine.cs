using Core.Data;
using Core.Game;
using Core.View;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.GameCore
{
    public class GameEngine : MonoBehaviour
        {
            public UnityEvent<GameInfo> OnGameSelected = new UnityEvent<GameInfo>();
            [SerializeField] private RectTransform viewContainer;

            private GameConfig gameConfig;
            private INotify notify;

            [Inject]
            public void construct(INotify notify, GameConfig gameConfig)
            {
                this.notify = notify;
                this.gameConfig = gameConfig;
            }

            private void OnEnable()
            {
                OnGameSelected.AddListener(notify.GameSelected);
            }

            private void OnDisable()
            {
                OnGameSelected.RemoveListener(notify.GameSelected);
            }
        
            public void InstantiateGame(GameInfo gameInfo)
            {
                var game = Instantiate(Resources.Load(gameConfig.Path 
                                                      + gameInfo.PrefabName), gameConfig.Container);
                Debug.Log(game.name);
            }
        }
}