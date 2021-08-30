using Core.MVVM.Home;

namespace Core.MVVM {
	public interface IViewModel {
	}

	public interface IViewModel<TModel> : IViewModel where TModel : IModel {
		TModel Model { get; set; }
		void Init();
	}

	public interface IModel {
		event PropertyChangeDelegate OnPropertyChange;
		void ForceUpdate();
	}
}