using System.Collections;
using Core.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.SquareFall
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ObjectPooling pool;
        [SerializeField] private Enemies enemy;
        [SerializeField] private Line line;
        [SerializeField] private Player player;
       
        [SerializeField] private int minRotationRange = -20;
        [SerializeField] private int maxRotationRange = 20;

        private bool canplay;
        
        private void Start()
        {
            canplay = true;
            StartCoroutine(CreateEnemies());
        }

        private void OnEnable()
        {
            player.onGameOver.AddListener(gameOver);
        }

        private void OnDisable()
        {
            player.onGameOver.RemoveListener(gameOver);
        }

        private void gameOver()
        {
            canplay = false;
        }

        private IEnumerator CreateEnemies()
        {
            while (canplay)
            {
                yield return new WaitForSeconds(0.8f);

                var en = pool.SpawnToPool(enemy.transform.gameObject.name);
                var angle = Random.Range(minRotationRange, maxRotationRange);
                en.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
                line.OnPooling.AddListener(pool.BackToPool);
               
                yield return en;
            }
        }

    }
}