using Core.View;
using Zenject;

namespace Core
{
    public class Startup : IInitializable
    {
        private readonly IViewManager viewManager;

        public Startup(IViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        void IInitializable.Initialize()
        {
            start();
        }

        private void start()
        {
            viewManager.Startup();
        }
    }
}