using System;

namespace Core.MVVM.Command.Image {
	public class RemoveImageCommand : ICommand<int> {
		private event Action<int> callbacks;

		public bool CanExecute(int data) {
			return true;
		}

		public void Execute(int data) {
			if (!CanExecute(data)) {
				return;
			}

			callbacks?.Invoke(data);
		}

		public void Subscribe(Action<int> callback) {
			callbacks += callback;
		}
	}
}