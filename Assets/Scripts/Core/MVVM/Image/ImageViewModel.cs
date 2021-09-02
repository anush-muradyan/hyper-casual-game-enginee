using System.Collections.Generic;
using System.Linq;
using Core.MVVM.Command;
using Core.MVVM.Command.Image;
using UnityEngine;

namespace Core.MVVM.Image {
	public class ImageViewModel : IViewModel<ImageModel> {
		public ImageModel Model { get; set; }
		public ICommand<List<Texture2D>> LoadTexturesCommand { get; }
		public ICommand<int> RemoveImageCommand { get; }

		public ImageViewModel() {
			LoadTexturesCommand = new LoadTexturesCommand();
			RemoveImageCommand = new RemoveImageCommand();
		}

		public void Init() {
			LoadTexturesCommand.Subscribe(data => Model.Textures = data);
			RemoveImageCommand.Subscribe(index => Model.Textures.RemoveAt(index));
		}

		public void LoadImages() {
			LoadTexturesCommand?.Execute(Resources.LoadAll<Texture2D>("Textures").ToList());
		}

		public void RemoveImageAt() {
			RemoveImageCommand?.Execute(Model.Textures.Count - 1);
		}
	}
}