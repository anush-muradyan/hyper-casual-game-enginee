using System;
using Core.MVVM.Home;
using Core.MVVM.View;
using UnityEngine.Events;

namespace Core.MVVM.GameView {
    public class GameModel : IModel {

        private int score;
        public UnityEvent OnRestartGame = new UnityEvent();
        
        public int Score {
            get => score;
            set {
                score = value;
                OnPropertyChange?.Invoke(nameof(Score),value);
            }
        }
            
        
        public event PropertyChangeDelegate OnPropertyChange;
        
        public void ForceUpdate() {
        }

        public void PropertyChange(string propertyName, object value) {
            if (propertyName == null) {
                throw new Exception("Invalid property");
            }

            OnPropertyChange?.Invoke(propertyName, value);
        }
      
    }
}