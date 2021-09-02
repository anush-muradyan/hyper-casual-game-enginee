using Core.MVVM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Image {
	public class ImageView : View<ImageViewModel, ImageModel> {
		[SerializeField] private ImageCollectionComponentControl imageCollectionComponentControl;

		[SerializeField] private Button loadImagesButton;
		[SerializeField] private Button deleteImageButton;
		[SerializeField] private Button addImageButton;

		private void Start() {
			setButtonState(false);

			loadImagesButton.onClick.AddListener(loadImagesButtonClick);
			deleteImageButton.onClick.AddListener(deleteImage);
			addImageButton.onClick.AddListener(addImage);
		}

		public override void Bind() {
			base.Bind();
			Controls.Add(imageCollectionComponentControl);
		}


		private void loadImagesButtonClick() {
			setButtonState(true);
			loadImagesButton.gameObject.SetActive(false);
			ViewModel.LoadImages();
		}

		private void deleteImage() {
			ViewModel.RemoveImageAt();
		}

		private void addImage() {
			// ViewModel.OnAddImage?.Invoke(imagePrefab, imageContainer);
		}

		private void setButtonState(bool state) {
			deleteImageButton.gameObject.SetActive(state);
			addImageButton.gameObject.SetActive(state);
		}

		protected override void Disposing() {
			base.Disposing();
			loadImagesButton.onClick.RemoveListener(loadImagesButtonClick);
			deleteImageButton.onClick.RemoveListener(deleteImage);
			addImageButton.onClick.RemoveListener(addImage);
		}
	}
}