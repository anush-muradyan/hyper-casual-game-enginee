using Core.Pooling;
using UnityEngine;

namespace Games.SquareFall
{
    public class DangerZone : MonoBehaviour
    {
        [SerializeField] private ObjectPooling objectPooling;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var a = other.GetComponent<IPoolingUnit>();
             if (a != null)
             {
                 objectPooling.BackToPool(other.gameObject);
             }

          
        }
    }
}
