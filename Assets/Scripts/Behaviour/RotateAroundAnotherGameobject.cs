using UnityEngine;

namespace Behaviour
{
    public abstract class RotateAroundAnotherGameobject : MonoBehaviour, IMove
    {
        [SerializeField] private Transform circleTransform;
        
        private int dir = 1;

        public void Move()
        {
            transform.RotateAround(circleTransform.position,new Vector3(0f,0,0.01f),0.5f * dir);
          
            if (!Input.GetKeyDown(KeyCode.Mouse0))
            {
                return;
            }
           
            dir *= -1;
        }
    }
}