using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game
{
    public struct GameInfo
    {
        public string Name { get; }
        public string Code { get; }

        public GameInfo(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Code)}: {Code}";
        }
    }

    public interface IGameItem
    {
        event Action<GameInfo> OnSelected;
        void Setup(GameInfo gameInfo);
    }

    public class GameItem : MonoBehaviour, IGameItem
    {
        [SerializeField] private TextMeshProUGUI gameTitleText;
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
            gameTitleText.text = gameInfo.Name;
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