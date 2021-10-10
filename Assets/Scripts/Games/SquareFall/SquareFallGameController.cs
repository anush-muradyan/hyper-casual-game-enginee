using Core.GameStates;
using Core.InputHandler;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Games.SquareFall {
    //IGamePlay interface need to have game play methods and events  no only this class
    public class SquareFallGameController : BaseGameController{
        [SerializeField] private Player player;
        [SerializeField] private Spawner spawner;

        [SerializeField] private TextMeshProUGUI startMessage;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button closeGameButton;
        public UnityEvent OnGameClose = new UnityEvent();
        public UnityEvent<int> OnGameScoreChange = new UnityEvent<int>();

        private Session session;
        private IInput input;

        [Inject]
        private void constuct(Session session, IInput input) {
            this.session = session;
            this.input = input;
        }

        public override void StartGame() {
            session.State = GameState.Idle;
            input.OnTouch.AddListener(startGame);
        }

        private void OnEnable() {
            player.onScore.AddListener(onScore);
            player.onLoose.AddListener(onGameLoose);
            restartButton.onClick.AddListener(onRestartButtonClick);
            closeGameButton.onClick.AddListener(onGameClose);
        }

        private void OnDisable() {
            player.onScore.RemoveListener(onScore);
            player.onLoose.RemoveListener(onGameLoose);
            restartButton.onClick.RemoveListener(onRestartButtonClick);
            closeGameButton.onClick.RemoveListener(onGameClose);
        }

        private void startGame() {
            startMessage.enabled = false;
            session.State = GameState.Playing;
            spawner.Run();
            input.OnTouch.RemoveListener(startGame);
        }

        public override void RestartGame() {
            spawner.Stop();
            session.Score = 0;
            OnGameScoreChange?.Invoke(session.Score);
            player.reset();
            session.State = GameState.Playing;

            spawner.Run();
        }

        private void onGameClose() {
            session.State = GameState.GameOver;
            OnGameClose?.Invoke();
        }

        private void onScore() {
            session.Score++;
            OnGameScoreChange?.Invoke(session.Score);
        }

        private void onGameLoose() {
            spawner.Stop();
            session.State = GameState.GameOver;
            session.Score = 0;
        }

        private void onRestartButtonClick() {
            RestartGame();
        }

        public override void Quit() {
            spawner.Stop();
            transform.gameObject.SetActive(false);
        }

        public override void Show() {
            transform.gameObject.SetActive(true);
            RestartGame();
        }
    }
}