using Core.GameStates;
using DefaultNamespace.Games;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Games.SquareFall {
    public class SquareFallGameController : MonoBehaviour, IGamePlay {
        [SerializeField] private Spawner spawner;
        [SerializeField] private Player player;

        [SerializeField] private TextMeshProUGUI startMessage;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private Button restartButton;

        private SessionSquareFall sessionSquareFall;

        [Inject]
        private void constuct(SessionSquareFall sessionSquareFall) {
            this.sessionSquareFall = sessionSquareFall;
        }

        private void Start() {
            sessionSquareFall.StartMessage = "Tap to start play!";
            startMessage.text = sessionSquareFall.StartMessage;
        }

        private void OnEnable() {
            player.onScore.AddListener(OnScore);
            player.onLoose.AddListener(OnGameLoose);
            spawner.OnRemoveStartMessage.AddListener(onRemoveStartMessage);
            restartButton.onClick.AddListener(onRestartButtonClick);
        }

        private void OnDisable() {
            player.onScore.RemoveListener(OnScore);
            player.onLoose.RemoveListener(OnGameLoose);
            spawner.OnRemoveStartMessage.RemoveListener(onRemoveStartMessage);
            restartButton.onClick.RemoveListener(onRestartButtonClick);
        }


        private void RestartGame() {
            spawner.Stop();
            sessionSquareFall.Score = 0;
            score.text = $"Score: {sessionSquareFall.Score}";
            player.reset();
            sessionSquareFall.State = GameState.Playing;

            spawner.Run();
        }

        private void onRemoveStartMessage(string text) {
            startMessage.text = text;
        }

        private void OnScore() {
            sessionSquareFall.Score += 10;
            score.text = $"Score: {sessionSquareFall.Score}";
            Debug.Log(sessionSquareFall.Score);
        }

        private void OnGameLoose() {
            spawner.Stop();
            sessionSquareFall.State = GameState.GameOver;
            sessionSquareFall.Score = 0;
        }

        private void onRestartButtonClick() {
            RestartGame();
        }
    }
}