using UnityEngine;
using Zenject;

namespace Core.View.Factory
{
    public class ViewFactory : AbstractFactory.Factory<ViewConfig>
    {
        private readonly DiContainer container;

        public ViewFactory(ViewConfig viewConfig, DiContainer container) : base(viewConfig)
        {
            this.container = container;
        }

        protected override T InternalCreate<T>(T prefab)
        {
            var item = Object.Instantiate(prefab, Config.Container);
            container.Inject(item);
            return item;
        }
    }
}