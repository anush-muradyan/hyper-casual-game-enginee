using Core.MVVM.GameSelectorView;
using Core.View.Factory;
using IFactory = Core.AbstractFactory.IFactory;

namespace Core.Startup {
    public class Navigator {
        private readonly ViewFactory viewFactory;
        private readonly Context.Context context;

        public Navigator(ViewFactory viewFactory, Context.Context context) {
            this.viewFactory = viewFactory;
            this.context = context;
        }

        public void Startup() {
            showGameSelector();
        }

        private void showGameSelector() {
            var view = viewFactory.Create<MVVM.GameSelectorView.GameSelectorView>();
            context.Factory = view as IFactory;
            view.Init(new GameSelectorModel());
        }
    }
}