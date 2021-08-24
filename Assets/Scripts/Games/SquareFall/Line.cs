using UnityEngine;
using UnityEngine.Events;

namespace Games.SquareFall
{
    public class Line : MonoBehaviour
    {
        
        public UnityEvent<string> OnPooling = new UnityEvent<string>();

        private void OnTriggerStay2D(Collider2D other)
        {
            other.transform.position = new Vector3(0f, 5f, 0f);
            other.transform.gameObject.SetActive(false);
            OnPooling?.Invoke(other.gameObject.name.Split('(')[0]);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnPooling.RemoveAllListeners();
        }
    }
}
