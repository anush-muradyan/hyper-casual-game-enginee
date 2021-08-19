using Core.View;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core
{
    public class GameRunner : MonoBehaviour
    {
        private ViewManager viewManager;
        public UnityEvent<string> aaa = new UnityEvent<string>();

        [Inject]
        public void construct(ViewManager viewManager)
        {
            this.viewManager = viewManager;
        }


        private void OnEnable()
        {
            Debug.Log("game Runner onenable");
        }

        private void OnDisable()
        {
        }


        private void SetGame(string gameName)
        {
            // var obj = FindObjectsOfType<Game.Game>().FirstOrDefault(obj => obj.name.Equals(gameName));
            // if (!obj)
            // {
            //     Debug.LogError("We dont have that game!");
            //     return;
            // }
            // obj.startGame();
            //

            Debug.LogError("aaasasadasassvsvs");
        }
    }
}