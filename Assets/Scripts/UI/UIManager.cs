using Managers;
using UI.View;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HomeView homeView;
        [SerializeField] private GameView gameView;
        [SerializeField] private LooseView looseView;

        private void Start()
        {
            homeView.Show();
            
        }
    }
}