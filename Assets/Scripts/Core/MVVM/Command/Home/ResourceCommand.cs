using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Core.MVVM.Command.Home
{
    public class ResourceCommand<TResource> : ICommand where TResource : Object {
        private readonly string path;
        private readonly Action<TResource> executor;

        public ResourceCommand(string path, Action<TResource> executor) {
            this.path = path;
            this.executor = executor;
        }

        public void Execute() {
            var collection = Resources.LoadAll<TResource>(path);
            var itemIndex = Random.Range(0, collection.Length);
            executor?.Invoke(collection[itemIndex]);
        }
    }
}