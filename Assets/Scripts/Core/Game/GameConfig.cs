using Core.AbstractFactory;
using UnityEngine;

namespace Core.Game
{
    public struct GameConfig : IFactoryConfig
    {
        public string Path { get; }
        public RectTransform Container { get; }

        public GameConfig(string path, RectTransform container)
        {
            Path = path;
            Container = container;
        }
    }
}