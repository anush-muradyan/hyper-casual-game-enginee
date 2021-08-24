using Behaviour;
using UnityEngine;
using UnityEngine.Events;

namespace Games.SquareFall
{
    public  class Player : LineXMove
    {
        public UnityEvent onGameOver;
        
        private bool gameOver;
        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            gameOver = true;
            transform.position=Vector3.zero;
            transform.gameObject.SetActive(false);
            
            onGameOver?.Invoke();
        }
        
    }
}
