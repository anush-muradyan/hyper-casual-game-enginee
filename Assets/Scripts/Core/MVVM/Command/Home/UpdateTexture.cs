using System.Collections.Generic;
using Core.MVVM.Home;
using UnityEngine;

namespace Core.MVVM.Command.Home {
    public class UpdateTexture {
        public UpdateTexture() {
        }

        public void UpdateTextures(ObservableList<Texture2D> observableList, List<Texture2D> list) {
            observableList.AddRange(list);
        }

        public void UpdateTextures(ObservableList<Texture2D> observableList, Texture2D texture) {
            observableList.Add(texture);
        }

        public void UpdateInsertTextures(ObservableList<Texture2D> observableList, Texture2D texture) {
            observableList.Insert(0, texture);
        }

        public void UpdateRemoveTextures(ObservableList<Texture2D> observableList) {
            observableList.RemoveAt(observableList.Count - 1);
        }
    }
}