using UnityEngine;

namespace Core.Data
{
    public class ScreenSize : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        public Vector2 Size { get; private set; }

        private void Awake()
        {
            var point = camera.ScreenPointToRay(Vector3.right).origin;
            Size = new Vector2(point.x, point.y);
        }
    }
}