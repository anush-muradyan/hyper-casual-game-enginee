using System.Collections;
using Core.GameStates;
using Core.ObjectPooling;
using ObjectPoolingV2.CorePooling.Generator;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Games.SquareFall {
    public class Spawner : MonoBehaviour {
        [SerializeField, Range(0f, 1f)] private float probability = 0.95f;
        [SerializeField] private float generationDelay = 1f;

        private Session session;
        private EnemyGenerator enemyGenerator;
        private BonusItemGenerator bonusItemGenerator;
        private PoolManager poolManager;
        private Coroutine coroutine;


        [Inject]
        private void construct(Session session, EnemyGenerator enemyGenerator,
            BonusItemGenerator bonusItemGenerator, PoolManager poolManager) {
            this.session = session;
            this.enemyGenerator = enemyGenerator;
            this.bonusItemGenerator = bonusItemGenerator;
            this.poolManager = poolManager;
        }


        public void Run() {
            coroutine = StartCoroutine(createUnit());
        }

        public void Stop() {
            StopCoroutine(coroutine);
            poolManager.UnUseAll();
        }

        public IEnumerator createUnit() {
            while (session.State == GameState.Playing) {
                yield return new WaitForSeconds(generationDelay);
                var unit = Random.value < probability ? enemyGenerator.Generate() : bonusItemGenerator.Generate();
            }
        }
    }
}