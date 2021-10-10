using Core.MVVM.Controls;
using Core.MVVM.View;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.GameView {
    public class GameView : View<GameViewModel, GameModel> {
        [SerializeField] private TextMeshProUGUIStaticComponent scoreTextComponent;
        [SerializeField] private Button restartGameButton;
     //   [SerializeField] private Button quitGameButton;

        public override void Bind() {
            base.Bind();
            Controls.Add(scoreTextComponent);
        }

        protected override void OnEnable() {
            base.OnEnable();
            restartGameButton.onClick.AddListener(onRestartButtonClicked);
         //   quitGameButton.onClick.AddListener(onQuitGameButtonClick);
        }

        private void onRestartButtonClicked() {
            ViewModel.RestartGameCommand.Execute();
        }

        private void onQuitGameButtonClick() {
           // ViewModel.QuitGameCommand.Execute();
        }
    }
}