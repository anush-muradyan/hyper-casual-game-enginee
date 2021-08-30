using Core.MVVM.Command;
using Core.MVVM.Command.Home;

namespace Core.MVVM.Home {
	public class HomeViewModel : IViewModel<HomeModel> {
		public HomeModel Model { get; set; }

		public ICommand<string> UpdateContentCommand { get; }

		public HomeViewModel() {
			UpdateContentCommand = new StringCommand();
		}

		public void Init() {
			UpdateContentCommand.Subscribe(data => Model.ContentText = data);
		}
	}
}