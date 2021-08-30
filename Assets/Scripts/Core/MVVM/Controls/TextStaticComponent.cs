using UnityEngine.UI;

namespace Core.MVVM.Controls {
	public class TextStaticComponent : StaticComponentControl<Text> {
		public override void SetValue(object value) {
			var str = value.ToString();
			Property.text = str;
		}
	}
}