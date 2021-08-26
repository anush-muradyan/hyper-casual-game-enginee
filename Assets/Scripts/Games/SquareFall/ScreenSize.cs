using UnityEngine;

namespace Games.SquareFall
{
    public  class ScreenSize : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        public float height { get; private set; }
        public float width { get; private set; }


        private void Start()
        {
            var a= camera.ScreenPointToRay(Vector3.right).origin;
            height = a.x;
            width = a.y;
        }

        
    }
}