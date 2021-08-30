using System;

namespace Core.MVVM.Command.Home {
	public class StringCommand : ICommand<string> {
		private readonly Action<string> executor;
		private readonly Func<string, bool> canExecute;

		public StringCommand(Action<string> executor, Func<string, bool> canExecute = null) {
			this.executor = executor;
			this.canExecute = canExecute;
		}

		public void Execute(string data) {
			if (!CanExecute(data)) {
				return;
			}

			executor?.Invoke(data);
		}

		private bool CanExecute(string data) {
			return canExecute != null && canExecute.Invoke(data);
		}
	}
}