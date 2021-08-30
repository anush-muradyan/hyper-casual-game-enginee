using UnityEngine;

namespace Core.Data
{
    public  class ScreenSize : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        public float height { get; private set; }
        public float width { get; private set; }


        private void Awake()
        {
            var a= camera.ScreenPointToRay(Vector3.right).origin;
            width = a.x;
            height = a.y;
        }

        
    }
}