using System;

namespace Core.MVVM.Command.Home {
	public class StringCommand : ICommand<string> {
		private event Action<string> callbacks;

		public bool CanExecute(string data) {
			return true;
		}

		public void Execute(string data) {
			if (!CanExecute(data)) {
				return;
			}

			callbacks?.Invoke(data);
		}

		public void Subscribe(Action<string> callback) {
			callbacks += callback;
		}
	}
}