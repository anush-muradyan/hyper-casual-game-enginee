using Core.ObjectPooling;
using DG.Tweening;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;
using UnityEngine.Events;

namespace Games.SquareFall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform moveTransform;
        [SerializeField] private PoolManager poolManager;

        public UnityEvent onLoose = new UnityEvent();
        public UnityEvent onScore = new UnityEvent();


        private float fullMovePathLenght;
        private Vector3 finalPos;
        private float moveDuration;
        private int dir = 1;
        private int velocity = 2;
        private Tweener moveTweener;

        private void Start()
        {
            transform.position = Vector3.zero;

            finalPos = 2 * moveTransform.localScale;
            fullMovePathLenght = Mathf.Abs(2 * finalPos.x);
            moveDuration = 2 * Mathf.Abs(finalPos.x) / velocity;

            StartMovement(dir, moveDuration / 2);
        }

        private void Move(int direction, float duration)
        {
            moveTweener?.Kill();
            moveTweener = transform.DOMoveX(direction * finalPos.x, duration).OnComplete(() =>
                {
                    dir *= -1;
                    duration = velocity;
                    Move(dir, duration);
                })
                .SetEase(Ease.Linear);
        }

        private void StartMovement(int direction, float duration)
        {
            Move(direction, duration);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;


            var length = fullMovePathLenght - Mathf.Abs(finalPos.x * dir - transform.position.x);
            var time = (velocity * length) / Mathf.Abs(2 * finalPos.x);
            dir *= -1;
            Move(dir, time);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            var unit = other.GetComponent<AbstractFactoryPoolObjectItem>();
            if (unit == null)
            {
                return;
            }

            var canplay = unit.OnPooling?.Invoke(true);
            if (canplay.Equals(false))
            {
                gameObject.SetActive(false);
                onLoose?.Invoke();
                poolManager.UnUseAll();
                return;
            }

            unit.UnUse();
            onScore?.Invoke();
        }

        public void reset()
        {
            transform.position = Vector3.zero;
            transform.gameObject.SetActive(true);
        }
    }
}