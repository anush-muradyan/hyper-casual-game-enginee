using Core.AbstractFactory;
using UnityEngine;

namespace Core.View.Factory
{
    public class ViewFactory : Factory<ViewConfig>
    {
        public ViewFactory(ViewConfig viewConfig) : base(viewConfig)
        {
        }

        protected override T InternalCreate<T>(T prefab)
        {
            return Object.Instantiate(prefab, Config.Container);
        }
    }
}