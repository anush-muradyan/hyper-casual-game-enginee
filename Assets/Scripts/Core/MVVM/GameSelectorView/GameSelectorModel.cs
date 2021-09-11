using System;
using System.Collections.Generic;
using Core.Data;
using Core.MVVM.Home;
using Core.MVVM.View;

namespace Core.MVVM.GameSelectorView {
    public class GameSelectorModel : IModel {
        public event PropertyChangeDelegate OnPropertyChange;

        private List<GameInfo> gameInfos;

        public List<GameInfo> GameInfos {
            get => gameInfos;
            set {
                gameInfos = value;
                PropertyChange(nameof(GameInfos), value);
            }
        }

        public void PropertyChange(string propertyName, object value) {
            if (propertyName == null) {
                throw new Exception("Invalid property");
            }

            OnPropertyChange?.Invoke(propertyName, value);
        }

        public void ForceUpdate() {
        }
    }
}