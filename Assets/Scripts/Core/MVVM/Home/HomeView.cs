using Core.MVVM.Controls;
using Core.MVVM.View;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Home {
	public class HomeView : View<HomeViewModel, HomeModel> {
		[SerializeField] private TextStaticComponent contentTextStatic;
		[SerializeField] private RawImageCollectionStaticComponent imageCollectionStaticComponent;
		[SerializeField] private InputField inputField;
		[SerializeField] private Button button;
		[SerializeField] private Button loadTexturesButton;
		
		[SerializeField] private Button addTextureButton;
		[SerializeField] private Button insertTextureButton;
		[SerializeField] private Button removeTextureButton;

		public override void Bind() {
			base.Bind();
			Controls.Add(contentTextStatic);
			Controls.Add(imageCollectionStaticComponent);
		}

		protected override void OnEnable() {
			base.OnEnable();
			button.onClick.AddListener(onButtonClick);
			loadTexturesButton.onClick.AddListener(onLoadTexturesButtonClick);
			addTextureButton.onClick.AddListener(onAddTextureButton);
			insertTextureButton.onClick.AddListener(onInsertTexturesButtonClick);
			removeTextureButton.onClick.AddListener(onRemoveTextureButton);
		}

		protected override void OnDisable() {
			base.OnDisable();
			button.onClick.RemoveListener(onButtonClick);
			loadTexturesButton.onClick.RemoveListener(onLoadTexturesButtonClick);
			addTextureButton.onClick.RemoveListener(onAddTextureButton);
			insertTextureButton.onClick.RemoveListener(onInsertTexturesButtonClick);
			removeTextureButton.onClick.RemoveListener(onRemoveTextureButton);
		}

		private void onButtonClick() {
			ViewModel.UpdateContentCommand.Execute(inputField.text);
		}

		private void onLoadTexturesButtonClick() {
			ViewModel.LoadTexturesCommand.Execute();
		}

		private void onAddTextureButton()
		{
			ViewModel.LoadTexture.Execute();
		}

		private void onInsertTexturesButtonClick()
		{
			ViewModel.InsertTexture.Execute();
		}

		private void onRemoveTextureButton()
		{
			ViewModel.RemoveTexture.Execute();
		}
	}
}