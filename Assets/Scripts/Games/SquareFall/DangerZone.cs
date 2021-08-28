using Core.ObjectPooling;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;

namespace Games.SquareFall
{
    public class DangerZone : MonoBehaviour
    {
        [SerializeField] private PoolManager poolManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var a = other.GetComponent<AbstractFactoryPoolObjectItem>();
             if (a != null)
             {
                 a.UnUse();
             }

        }
    }
}
