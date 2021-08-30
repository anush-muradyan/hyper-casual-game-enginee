using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Core.MVVM.Home {
	public delegate void PropertyChangeDelegate(string propertyName, object obj);

	public class HomeModel : IModel {
		private string contentText;
		private List<Texture2D> textures;

		public string ContentText {
			get => contentText;
			set {
				contentText = value;
				PropertyChange(ContentText);
			}
		}

		public List<Texture2D> Textures {
			get => textures;
			set {
				textures = value;
				PropertyChange(Textures);
			}
		}

		public event PropertyChangeDelegate OnPropertyChange;

		private void PropertyChange<T>(T value, [CallerMemberName] string propertyName = null) {
			if (string.IsNullOrEmpty(propertyName)) {
				throw new Exception("Invalid Property");
			}

			OnPropertyChange?.Invoke(propertyName, value);
		}

		public void ForceUpdate() {
			var type = GetType();
			var props = type.GetProperties();
			foreach (var propertyInfo in props) {
				var value = propertyInfo.GetValue(this);
				PropertyChange(value, propertyInfo.Name);
			}
		}
	}
}