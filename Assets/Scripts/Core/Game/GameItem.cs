using System;
using Core.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game
{
    public class GameItem : MonoBehaviour, IGameItem
    {
        [SerializeField] private Text gameTitleText;
        [SerializeField] private Button button;

        private GameInfo gameInfo;
        public event Action<GameInfo> OnSelected;

        void IGameItem.Setup(GameInfo gameInfo)
        {
            this.gameInfo = gameInfo;
            updateUI();
        }

        private void updateUI()
        {
            gameTitleText.text = gameInfo.Title;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(onButtonClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(onButtonClick);
        }

        private void onButtonClick()
        {
            OnSelected?.Invoke(gameInfo);
        }
    }
}