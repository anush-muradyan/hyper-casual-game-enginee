using GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class LooseView:AbstractView
    {
        [SerializeField] private Button restartGame;
        [SerializeField] private Button continueButton;


        protected override void OnEnable()
        {
            base.OnEnable();
            restartGame.onClick.AddListener(RestartGame);
            continueButton.onClick.AddListener(ContinueGame);
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            restartGame.onClick.RemoveListener(RestartGame);
            continueButton.onClick.RemoveListener(RestartGame);

        }

        public void LooseGame()
        {
            throw new System.NotImplementedException();
        }

        public void RestartGame()
        {
            Debug.LogError("Restart game");
        }

        private void ContinueGame()
        {
            Debug.LogError("Continue game");

        }
    }
}