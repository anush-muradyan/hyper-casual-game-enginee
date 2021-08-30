using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Controls {
	public class RawImageStaticComponent : StaticComponentControl<RawImage> {
		public override void SetValue(object value) {
			var texture = value as Texture2D;
			if (texture == null) {
				return;
			}

			Property.texture = texture;
		}
	}
}