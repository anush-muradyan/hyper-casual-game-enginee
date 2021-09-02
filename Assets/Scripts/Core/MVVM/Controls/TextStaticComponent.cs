using UnityEngine.UI;

namespace Core.MVVM.Controls {
	public class TextStaticComponent : StaticComponentControl<Text> {
		public override void SetValue(object value) {
			if (value == null) {
				return;
			}
			var str = value.ToString();
			Property.text = str;
		}
	}
}