using System;

namespace Core.MVVM.Home {
	public delegate void PropertyChangeDelegate(string propertyName, object obj);

	public class HomeModel : IModel {
		private string contentText;

		public string ContentText {
			get => contentText;
			set {
				contentText = value;
				PropertyChange(nameof(ContentText), value);
			}
		}

		public event PropertyChangeDelegate OnPropertyChange;

		private void PropertyChange(string propertyName, object value) {
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
				PropertyChange(propertyInfo.Name, value);
			}
		}
	}
}