using System.Linq;
using Core.MVVM.Command;
using Core.MVVM.Command.Home;
using UnityEngine;

namespace Core.MVVM.Home
{
	public class HomeViewModel : IViewModel<HomeModel>
	{
		public HomeModel Model { get; set; }
		private UpdateTexture updateTexture = new UpdateTexture();
		public ICommand<string> UpdateContentCommand =>
			new StringCommand(data => Model.ContentText = data, data => !string.IsNullOrEmpty(data));

		public ICommand LoadTexturesCommand =>
			new ResourceCollectionCommand<Texture2D>(
				"Textures", collection
				=>	updateTexture.UpdateTextures(Model.Textures,collection.ToList())
				);

		public ICommand LoadTexture => new ResourceCommand<Texture2D>(
			"Textures", item =>
			{
				updateTexture.UpdateTextures(Model.Textures,item);
			});

		public ICommand InsertTexture => new ResourceCommand<Texture2D>(
			"Textures", item =>
			{
				updateTexture.UpdateInsertTextures(Model.Textures,item);
			});
		
		public ICommand RemoveTexture => new RemoveCommand<Texture2D>(
			()=> {
				updateTexture.UpdateRemoveTextures(Model.Textures);
			});
		
	}

}