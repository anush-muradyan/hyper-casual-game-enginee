using Core.View;
using Core.View.Factory;
using Zenject;

namespace Core
{
    public class Startup : IInitializable
    {
        private readonly IViewManager<ViewConfig> viewManager;

        public Startup(IViewManager<ViewConfig> viewManager)
        {
            this.viewManager = viewManager;
        }

        void IInitializable.Initialize()
        {
            start();
        }

        private void start()
        {
          //  viewManager.Startup();
        }
    }
}