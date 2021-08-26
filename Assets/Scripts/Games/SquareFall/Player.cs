using UnityEngine;
using UnityEngine.Events;

namespace Games.SquareFall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform moveTransform;
        
        public UnityEvent onGameOver = new UnityEvent();
        public UnityEvent onScore = new UnityEvent();
        
        private bool gameOver;
        private int score;

        private int dir = 1;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.right * (speed * dir * Time.deltaTime));

            if (Mathf.Abs(transform.position.x) >= Mathf.Abs((moveTransform.transform.localScale * 2f).x))
            {
                dir *= -1;
            }

            if (Input.GetMouseButtonDown(0))
            {
                dir *= -1;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var unit = other.GetComponent<IPoolingUnit>();
            if (unit == null)
            {
                return;
            }

            var canplay = unit.OnPooling?.Invoke(true);
            if (canplay.Equals(false))
            {
                gameObject.SetActive(false);
                onGameOver?.Invoke();
                return;
            }
            onScore?.Invoke();
            
        }

        public void reset()
        {
            gameOver = false;
            score = 0;
            transform.position = Vector3.zero;
            transform.gameObject.SetActive(true);
        }

        public void AddScore()
        {
            score += 10;
            Debug.Log(score);
        }
    }
}