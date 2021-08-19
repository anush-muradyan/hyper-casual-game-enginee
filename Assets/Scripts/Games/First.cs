using GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace Games
{
    public class First:Game,IGameStart
    {
       // [SerializeField] private Button startButton;

        // private void OnEnable()
        // {
        //     startButton.onClick.AddListener(StartGame);
        // }
        //
        // private void OnDisable()
        // {
        //     startButton.onClick.RemoveListener(StartGame);
        // }

        public void StartGame()
        { 
            //TODO 
        }
        
    }



    public class Game : MonoBehaviour, IGame
    {
        [SerializeField] private Button startButton;
        
    }
}