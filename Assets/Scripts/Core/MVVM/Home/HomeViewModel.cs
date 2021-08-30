using System.Linq;
using Core.MVVM.Command;
using Core.MVVM.Command.Home;
using UnityEngine;

namespace Core.MVVM.Home {
	public class HomeViewModel : IViewModel<HomeModel> {
		public HomeModel Model { get; set; }

		public ICommand<string> UpdateContentCommand =>
			new StringCommand(data => Model.ContentText = data, data => !string.IsNullOrEmpty(data));

		public ICommand LoadTexturesCommand =>
			new ResourceCollectionCommand<Texture2D>("Textures", collection => Model.Textures = collection.ToList());
	}
}