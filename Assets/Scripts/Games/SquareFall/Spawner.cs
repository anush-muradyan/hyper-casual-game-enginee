using System.Collections;
using ObjectPoolingV2.CorePooling.Generator;
using UnityEngine;

namespace Games.SquareFall
{
    public class Spawner:MonoBehaviour
    {
        [SerializeField] private EnemyGenerator enemyGenerator;
        [SerializeField] private BonusItemGenerator bonusItemGenerator;

        public bool canplay;
        private int count;
        private const float WAIT_FOR_SECOND = 0.7f;

        private Coroutine coroutine;
       

        public IEnumerator CreateEnemiesAndBonusItems()
        {
            while (canplay)
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