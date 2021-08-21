using UnityEngine;

namespace Core.AbstractFactory
{
    public abstract class Factory<TConfig> where TConfig : IFactoryConfig
    {
        protected TConfig Config { get; }

        protected Factory(TConfig config)
        {
            Config = config;
        }

        public T Create<T>() where T : Object
        {
            var name = typeof(T).Name;
            var prefab = Resources.Load<T>(Config.Path + $"/{name}");
            var obj = InternalCreate(prefab);
            return obj;
        }

        
        
        protected abstract T InternalCreate<T>(T prefab) where T : Object;
    }
}