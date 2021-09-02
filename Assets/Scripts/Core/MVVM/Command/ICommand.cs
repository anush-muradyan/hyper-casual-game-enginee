using System;

namespace Core.MVVM.Command {
	public interface ICommand<T> {
		bool CanExecute(T data);
		void Execute(T data);

		void Subscribe(Action<T> callback);
	}
}