using Core.MVVM.Home;

namespace Core.MVVM.View {
	public interface IViewModel {
	}

	public interface IViewModel<TModel> : IViewModel where TModel : IModel {
		TModel Model { get; set; }
	}

	public interface IModel {
		event PropertyChangeDelegate OnPropertyChange;
		void ForceUpdate();
	}
}