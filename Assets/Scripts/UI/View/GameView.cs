using GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class GameView:AbstractView,IGamePause,IGameResume,IGameLoose
    { 
        [SerializeField] private Button pauseGame;
        [SerializeField] private Button resumeGame;

        protected override void OnEnable()
        {
            pauseGame.onClick.AddListener(PauseGame);
            resumeGame.onClick.AddListener(ResumeGame);
        }

        protected override void OnDisable()
        {
            pauseGame.onClick.RemoveListener(PauseGame);
            resumeGame.onClick.RemoveListener(ResumeGame);
        }

        public void StartGame()
        {
            Show();
            Debug.LogError("Start game");
        }

        public void PauseGame()
        {
            Debug.LogError("Pause game");
        }

        public void ResumeGame()
        {
            Debug.LogError("Resume game");
        }

        public void LooseGame()
        {
            Debug.LogError("Loose game");
        }
    }
    
}