using UnityEngine;
using Zenject;

namespace Core.View.Factory {
    public class ViewFactory : AbstractFactory.Factory<ViewConfig>,IFactory {
        private readonly DiContainer container;

        public ViewFactory(ViewConfig viewConfig, DiContainer container) : base(viewConfig) {
            this.container = container;
        }

        protected override T InternalCreate<T>(T prefab) {
            var item = Object.Instantiate(prefab, Config.Container);
            container.Inject(item);
            return item;
        }
        public void Quit<T>(T item) where T : IFactory {
            Object.Destroy(item as Object);
        }
        
    }
}