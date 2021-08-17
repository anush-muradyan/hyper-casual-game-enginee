using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class HomeView : AbstractView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private GameView gameView;
        private GameManager gameManager;

        protected override void OnEnable()
        {
            base.OnEnable();
            startButton.onClick.AddListener(StartGame);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            startButton.onClick.RemoveListener(StartGame);

        }

        public void StartGame()
        {
            Hide();
            gameView.StartGame();
            gameManager.StartGame();
            Debug.LogError("Start game");
        }
    }
}