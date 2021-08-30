using System.Collections;
using Core.GameStates;
using ObjectPoolingV2.CorePooling.Generator;
using UnityEngine;
using Zenject.Asteroids;
using GameStates = Core.GameStates.GameStates;

namespace Games.SquareFall
{
    public class Spawner:MonoBehaviour
    {
        [SerializeField] private EnemyGenerator enemyGenerator;
        [SerializeField] private BonusItemGenerator bonusItemGenerator;
        
       
        private int count;
        private const float WAIT_FOR_SECOND = 0.7f;

        private Coroutine coroutine;

        private void Start()
        {
            GameStates.CanPlay = true;
            coroutine = StartCoroutine(CreateEnemiesAndBonusItems());
        }


        public void Run()
        {
            coroutine = StartCoroutine(CreateEnemiesAndBonusItems());
        }

        public void Stop()
        {
            StopCoroutine(coroutine);
        }

        public IEnumerator CreateEnemiesAndBonusItems()
        {
            while (GameStates.CanPlay)
            {
                yield return new WaitForSeconds(WAIT_FOR_SECOND);

                if (count++ >= 4)
                {
                    var bonusGameObject = bonusItemGenerator.Generate();
                    count = 0;
                    yield return bonusGameObject;
                    yield return new WaitForSeconds(WAIT_FOR_SECOND);
                }

                var enemyGameObject = enemyGenerator.Generate();
                
                ++count;
                yield return enemyGameObject;
                
            }
            
        }
        
    }
}