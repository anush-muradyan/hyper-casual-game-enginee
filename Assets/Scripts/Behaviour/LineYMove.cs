using UnityEngine;

namespace Behaviour
{
    public abstract class LineYMove : MonoBehaviour, IMove
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float speed = 3f;
        private int dir = 1;
        

        public void Move()
        {
            var point = camera.ScreenToWorldPoint(Vector3.up);
            transform.Translate(Vector3.up * speed * dir * Time.deltaTime);
           
            if (Mathf.Abs(transform.position.y) >= Mathf.Abs(point.y))
            {
                dir *= -1;
            }
            if (Input.GetMouseButtonDown(0))
            {
                dir *= -1;
            }
        }
        
    }
}