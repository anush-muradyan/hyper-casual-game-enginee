using UnityEngine.UI;

namespace Core.MVVM.Controls {
	public class TextComponent : ComponentControl<Text> {
		public override void SetValue(object value) {
			var str = value.ToString();
			Property.text = str;
		}
	}
}