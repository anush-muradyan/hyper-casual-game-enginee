using System.Collections.Generic;
using System.Linq;
using Core.MVVM.Command;
using Core.MVVM.Command.Image;
using Core.MVVM.Home;
using Core.MVVM.View;
using UnityEngine;

namespace Core.MVVM.Image {
	public class ImageViewModel : IViewModel<ImageModel> {
		public ImageModel Model { get; set; }

		public ICommand<List<Texture2D>> LoadTexturesCommand =>
			new LoadTexturesCommand(list => Model.Textures = new ObservableList<Texture2D>(list));

		public ICommand<int> RemoveImageCommand { get; }


		public void LoadImages() {
			LoadTexturesCommand?.Execute(Resources.LoadAll<Texture2D>("Textures").ToList());
		}

		public void RemoveImageAt() {
			RemoveImageCommand?.Execute(Model.Textures.Count - 1);
		}
	}
}