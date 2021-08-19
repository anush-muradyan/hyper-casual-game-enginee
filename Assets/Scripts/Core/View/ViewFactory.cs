using UnityEngine;

namespace Core.View
{
    public class ViewFactory
    {
        public T Create<T>(string path, RectTransform container) where T : Object
        {
            var name = typeof(T).Name;
            var prefab = Resources.Load<T>(path + $"/{name}");
            var view = Object.Instantiate(prefab, container);
            return view;
        }
    }
}