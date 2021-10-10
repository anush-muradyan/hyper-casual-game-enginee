using Zenject;

namespace Core.Startup {
    public class Startup : IInitializable {
        private readonly Navigator navigator;

        public Startup(Navigator navigator) {
            this.navigator = navigator;
        }

        public void Initialize() {
            navigator.Startup();
        }
    }
}