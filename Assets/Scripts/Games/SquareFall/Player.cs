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
        
        public UnityEvent onGameOver = new UnityEvent();
        public UnityEvent onScore = new UnityEvent();
        
        
        private Vector3 currentTargetPos;
        private Vector3 finalPos;
        private float duration;


        void Start()
        {
            transform.position = Vector3.zero;
            finalPos = 2 * moveTransform.localScale;
            currentTargetPos = finalPos;
            duration = 2f;
            transform.DOMoveX(finalPos.x, 1f).OnComplete(MoveObj(currentTargetPos,duration)).SetDelay(0.5f);
            
        }

        private TweenCallback MoveObj(Vector3 pos,float moveDuration)
        {
            transform.DOMoveX(pos.x, 2f).OnUpdate(OnChangeDirection).OnComplete(() => MoveObj(currentTargetPos,moveDuration));

            currentTargetPos = -currentTargetPos ;
            moveDuration = (finalPos.x - transform.position.x) / 2f;
            return null;
        }
      
        private void OnChangeDirection()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.DOKill();
                MoveObj(currentTargetPos,duration);
            }
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
                onGameOver?.Invoke();
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