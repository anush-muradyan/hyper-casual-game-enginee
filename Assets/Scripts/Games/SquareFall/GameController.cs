using UnityEngine;

namespace Games.SquareFall
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Spawner spawner;

        private Coroutine coroutine;
        private int score;

        private void Start()
        {
            startGame();
            player.onScore.AddListener(OnScore);
            player.onGameOver.AddListener(OnGameOver);
        }

        private void startGame()
        {
            
            spawner.canplay = true;
            coroutine=StartCoroutine(spawner.CreateEnemiesAndBonusItems());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && !spawner.canplay)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            StopCoroutine(coroutine);
            score = 0;
            player.reset();
            startGame();
        }
        
        private void OnScore()
        {
            score += 10;
            Debug.Log(score);
        }

        private void OnGameOver()
        {
            StopCoroutine(coroutine);
            spawner.canplay = false;
            score = 0;
            Debug.LogError("GAME OVER!");
          
        }

    }
}