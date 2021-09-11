using System.Collections;
using Core.GameStates;
using Core.ObjectPooling;
using ObjectPoolingV2.CorePooling.Generator;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

namespace Games.SquareFall {
    public class Spawner : MonoBehaviour {
        [SerializeField, Range(0f, 1f)] private float probability = 0.95f;
        [SerializeField] private float generationDelay = 1f;

        private SessionSquareFall sessionSquareFall;
        private EnemyGenerator enemyGenerator;
        private BonusItemGenerator bonusItemGenerator;
        private PoolManager poolManager;

        public UnityEvent<string> OnRemoveStartMessage = new UnityEvent<string>();
        private Coroutine coroutine;
        private bool firstRun;

        [Inject]
        private void construct(SessionSquareFall sessionSquareFall, EnemyGenerator enemyGenerator,
            BonusItemGenerator bonusItemGenerator, PoolManager poolManager) {
            this.sessionSquareFall = sessionSquareFall;
            this.enemyGenerator = enemyGenerator;
            this.bonusItemGenerator = bonusItemGenerator;
            this.poolManager = poolManager;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !firstRun) {
                firstRun = true;
                OnRemoveStartMessage?.Invoke(sessionSquareFall.StartMessage);
                Run();
            }
        }

        public void Run() {
            sessionSquareFall.State = GameState.Playing;
            coroutine = StartCoroutine(createUnit());
        }

        public void Stop() {
            StopCoroutine(coroutine);
            poolManager.UnUseAll();
            sessionSquareFall.State = GameState.GameOver;
        }

        public IEnumerator createUnit() {
            while (sessionSquareFall.State == GameState.Playing) {
                yield return new WaitForSeconds(generationDelay);
                var unit = Random.value < probability ? enemyGenerator.Generate() : bonusItemGenerator.Generate();
            }
        }
    }
}