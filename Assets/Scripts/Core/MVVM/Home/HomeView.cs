using System.Linq;
using Core.MVVM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Home {
	public class HomeView : View<HomeViewModel, HomeModel> {
		[SerializeField] private TextComponent contentText;
		[SerializeField] private InputField inputField;
		[SerializeField] private Button button;

		protected override void Bind() {
			base.Bind();
			Controls.Add(contentText);
		}

		protected override void OnEnable() {
			base.OnEnable();
			button.onClick.AddListener(onButtonClick);
		}

		protected override void OnDisable() {
			base.OnDisable();
			button.onClick.RemoveListener(onButtonClick);
		}
		
		private void onButtonClick() {
			ViewModel.UpdateContentCommand.Execute(inputField.text);
		}
	}
}