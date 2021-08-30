namespace Core.MVVM.Command {
	public interface ICommand<T> {
		void Execute(T data);
	}

	public interface ICommand {
		void Execute();
	}
}