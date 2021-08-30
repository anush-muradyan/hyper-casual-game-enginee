using Core.ObjectPooling;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;

namespace Games.SquareFall
{
    public class DangerZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var poolObject = other.GetComponent<AbstractFactoryPoolObjectItem>();
             if (poolObject != null)
             {
                 poolObject.UnUse();
             }

        }
    }
}
