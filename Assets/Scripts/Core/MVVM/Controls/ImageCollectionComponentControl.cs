using System.Collections.Generic;
using UnityEngine;

namespace Core.MVVM.Controls {
	public class ImageCollectionComponentControl : StaticComponentControl {
		[SerializeField] private UnityEngine.UI.Image imagePrefab;
		[SerializeField] private RectTransform imagesContainer;
		private List<UnityEngine.UI.Image> images;

		private void init() {
			if (images == null) {
				images = new List<UnityEngine.UI.Image>(new List<UnityEngine.UI.Image>());
			}

			clearImages();
		}

		private void clearImages() {
			var count = images.Count;
			for (int i = 0; i < count; i++) {
				Destroy(images[i].gameObject);
			}

			images?.Clear();
		}

		public override void SetValue(object value) {
			var textures = value as List<Texture2D>;
			if (textures == null) {
				return;
			}

			init();
			createImages(textures);
		}

		private void createImages(List<Texture2D> textures) {
			foreach (var texture in textures) {
				var image = createImage(texture);
				images.Add(image);
			}
		}

		private UnityEngine.UI.Image createImage(Texture2D texture) {
			var image = Instantiate(imagePrefab, imagesContainer);
			image.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.one * 0.5f);
			return image;
		}
	}
}