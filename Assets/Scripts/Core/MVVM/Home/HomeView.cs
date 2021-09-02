using Core.MVVM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Home {
	public class HomeView : View<HomeViewModel, HomeModel> {
		[SerializeField] private TextStaticComponent contentTextStatic;
		[SerializeField] private RawImageCollectionStaticComponent imageCollectionStaticComponent;
		[SerializeField] private InputField inputField;
		[SerializeField] private Button button;
		[SerializeField] private Button loadTexturesButton;

		public override void Bind() {
			base.Bind();
			Controls.Add(contentTextStatic);
			Controls.Add(imageCollectionStaticComponent);
		}

		protected override void OnEnable() {
			base.OnEnable();
			button.onClick.AddListener(onButtonClick);
			loadTexturesButton.onClick.AddListener(onLoadTexturesButtonClick);
		}

		protected override void OnDisable() {
			base.OnDisable();
			button.onClick.RemoveListener(onButtonClick);
			loadTexturesButton.onClick.RemoveListener(onLoadTexturesButtonClick);
		}

		private void onButtonClick() {
			ViewModel.UpdateContentCommand.Execute(inputField.text);
		}

		private void onLoadTexturesButtonClick() {
			ViewModel.LoadTexturesCommand.Execute();
		}
	}
}