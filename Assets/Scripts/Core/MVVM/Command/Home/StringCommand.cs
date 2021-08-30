using System;

namespace Core.MVVM.Command.Home {
	public class StringCommand : ICommand<string> {
		private event Action<string> callbacks;

		public bool CanExecute() {
			return true;
		}

		public void Execute(string data) {
			if (!CanExecute()) {
				return;
			}

			callbacks?.Invoke(data);
		}

		public void Subscribe(Action<string> callback) {
			callbacks += callback;
		}
	}
}