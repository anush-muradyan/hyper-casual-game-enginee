using System;
using UnityEngine;

namespace Behaviour
{
    public abstract class LineXMove : MonoBehaviour, IMove
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float speed ;
        [SerializeField] private Transform moveTransform;
        
        private int dir;
        private Vector3 point;
        private void Awake()
        {
            dir = 1;
            point = moveTransform == null ? 
                camera.ScreenToWorldPoint(Vector3.right) : moveTransform.transform.localScale*2f;
        }

        public void Move()
        {
            transform.Translate(Vector3.right * (speed * dir * Time.deltaTime));

            if (Mathf.Abs(transform.position.x) >= Mathf.Abs(point.x))
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
