using Core.AbstractFactory;
using UnityEngine;

namespace Core.View.Factory
{
    public struct ViewConfig : IFactoryConfig
    {
        public string Path { get; }
        public RectTransform Container { get; }

        public ViewConfig(string path, RectTransform container)
        {
            Path = path;
            Container = container;
        }
    }
}