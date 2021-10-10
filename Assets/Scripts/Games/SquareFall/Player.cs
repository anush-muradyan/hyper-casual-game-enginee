using Core.GameStates;
using Core.InputHandler;
using Core.ObjectPooling;
using DG.Tweening;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Games.SquareFall {
    public class Player : MonoBehaviour {
        [SerializeField] private Transform moveTransform;
        private PoolManager poolManager;
        private IInput input;
        private Session session;


        [Inject]
        private void construct(PoolManager poolManager, IInput input, Session session) {
            this.poolManager = poolManager;
            this.input = input;
            this.session = session;
        }

        public UnityEvent onLoose = new UnityEvent();
        public UnityEvent onScore = new UnityEvent();

        private Vector3 finalPos;
        private float moveDuration;
        private int dir = 1;
        private float velocity = 1.5f;
        private Tweener moveTweener;

        private void Start() {
            input.OnTouch.AddListener(changeMoveDirection);

            transform.position = Vector3.zero;
            finalPos = 2 * moveTransform.localScale;
            moveDuration = 2 * Mathf.Abs(finalPos.x) / velocity;
            StartMovement(dir, moveDuration / 2);
        }

        private void changeMoveDirection() {
            if (session.State != GameState.Playing) {
                return;
            }
            var length = Mathf.Abs(2 * finalPos.x) - Mathf.Abs(finalPos.x * dir - transform.position.x);
            var time = (velocity * length) / Mathf.Abs(2 * finalPos.x);
            dir *= -1;
            StartMovement(dir, time);
        }

        private void Move(int direction, float duration) {
            
            moveTweener?.Kill();
            moveTweener = transform.DOMoveX(direction * finalPos.x, duration).OnComplete(() => {
                    dir *= -1;
                    duration = velocity;
                    Move(dir, duration);
                })
                .SetEase(Ease.Linear);
        }

        private void StartMovement(int direction, float duration) {
            Move(direction, duration);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var unit = other.GetComponent<AbstractFactoryPoolObjectItem>();
            if (unit == null) {
                return;
            }

            var canplay = unit.OnPooling?.Invoke(true);
            if (canplay.Equals(false)) {
                gameObject.SetActive(false);
                onLoose?.Invoke();
                poolManager.UnUseAll();
                return;
            }

            unit.UnUse();
            onScore?.Invoke();
        }

        public void reset() {
            transform.gameObject.SetActive(true);
            transform.position = new Vector3(0f,transform.position.y);
        }
    }
}