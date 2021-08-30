using Core.GameStates;
using UnityEngine;

namespace Games.SquareFall
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Spawner spawner;
        
        private int score;

        private void Start()
        {
            player.onScore.AddListener(OnScore);
            player.onLoose.AddListener(OnGameLoose);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && ! GameStates.CanPlay)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            spawner.Stop();
            score = 0;
            player.reset();
            GameStates.CanPlay = true;
            spawner.Run();
        }
        
        private void OnScore()
        {
            score += 10;
            Debug.Log(score);
        }

        private void OnGameLoose()
        {
            spawner.Stop();
            GameStates.CanPlay = false;
            score = 0;
            Debug.LogError("GAME OVER!");
          
        }

    }
}