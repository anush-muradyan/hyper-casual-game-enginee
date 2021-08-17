using System;
using Games;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Managers.MainScene
{
    public enum GamesEnum
    {
        First,
        Second,
        Third
    }
    public class MainScene:MonoBehaviour
    {
        [SerializeField] private Button firstGameButton;
        [SerializeField] private Button secondGameButton;
        [SerializeField] private Button thirdGameButton;

        public UnityEvent<GamesEnum> a = new UnityEvent<GamesEnum>();
        
        private void OnEnable()
        {
            firstGameButton.onClick.AddListener(OnFirst);
            secondGameButton.onClick.AddListener(OnSecond);
            thirdGameButton.onClick.AddListener(OnThird);
        }

        private void OnDisable()
        {
            firstGameButton.onClick.RemoveListener(OnFirst);
            secondGameButton.onClick.RemoveListener(OnSecond);
            thirdGameButton.onClick.RemoveListener(OnThird);
        }

        private void OnFirst()
        {
            a?.Invoke(GamesEnum.First);
        }


        private void OnSecond()
        {
            a?.Invoke(GamesEnum.Second);
        }

        private void OnThird()
        {
            a?.Invoke(GamesEnum.Third);
        }
    }
}