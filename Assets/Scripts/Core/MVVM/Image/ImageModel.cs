using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVVM.Image {
	public class ImageModel : IModel {

		private List<Texture2D> textures;

		public List<Texture2D> Textures {
			get => textures;
			set {
				textures = value;
				PropertyChange(nameof(Textures), value);
			}
		}

		public event PropertyChangeDelegate OnPropertyChange;

		public void PropertyChange(string propertyName, object value) {
			if (propertyName == null) {
				throw new Exception("Invalid property");
			}

			OnPropertyChange?.Invoke(propertyName, value);
		}

		public void ForceUpdate() {
		}
	}
}