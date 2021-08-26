using System.Collections;
using Core.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.SquareFall
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ObjectPooling pool;
        [SerializeField] private Player player;
        [SerializeField] private ScreenSize screenSize;
        [SerializeField] private int minRotationRange ;
        [SerializeField] private int maxRotationRange ;

        private bool canplay;
        private int count;
        private const float waitForSecond=0.7f;

        private void Start()
        {
            startGame();
            player.onScore.AddListener(OnScore);
            player.onGameOver.AddListener(OnGameOver);
        }

        private void startGame()
        {
            canplay = true;
            StartCoroutine(CreateEnemiesAndBonusItems());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && !canplay)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            StopCoroutine(CreateEnemiesAndBonusItems());
            player.reset();
            startGame();
        }
        
        private void OnScore()
        {
            player.AddScore();
        }

        private void OnGameOver()
        {
            canplay = false;
            Debug.LogError("GAME OVER!");
        }

        private IEnumerator CreateEnemiesAndBonusItems()
        {
            while (canplay)
            {
                yield return new WaitForSeconds(waitForSecond);

                if (count++ >= 4)
                {
                   var bonusGameObject = pool.SpawnToPool<BonusItem>();
                   bonusGameObject = randomRotate(bonusGameObject);
                   
                   count = 0;
                   yield return bonusGameObject;
                   yield return new WaitForSeconds(waitForSecond);
                }
                
                var enemyGameObject = pool.SpawnToPool<Enemy>();
                enemyGameObject = randomRotate(enemyGameObject);
                ++count;
                yield return enemyGameObject;
            }
        }

        private GameObject randomRotate(GameObject gameObj)
        {
            var angle = Random.Range(minRotationRange, maxRotationRange);
            gameObj.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
            gameObj.transform.position = new Vector3(0f, Mathf.Abs(screenSize.width), 0f);
            return gameObj;
        }
    }
}