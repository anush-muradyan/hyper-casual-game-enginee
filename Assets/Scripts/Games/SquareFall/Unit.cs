using UnityEngine;

namespace Games.SquareFall
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}