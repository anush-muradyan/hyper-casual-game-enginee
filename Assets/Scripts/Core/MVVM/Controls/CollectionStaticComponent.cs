using System.Collections.Generic;
using UnityEngine;

namespace Core.MVVM.Controls {
	public class CollectionStaticComponent<T, TComponent> : StaticComponentControl
		where T : class where TComponent : ComponentControl {
		[SerializeField] private TComponent component;
		[SerializeField] private Transform container;

		private List<TComponent> components;

		public sealed override void SetValue(object value) {
			var collection = value as IEnumerable<T>;
			if (collection == null) {
				return;
			}

			initComponents();
			foreach (var enumerable in collection) {
				var item = useItem(enumerable);
				components.Add(item);
			}
		}

		private void initComponents() {
			if (components == null || components.Count == 0) {
				components = new List<TComponent>();
			}

			clearComponents();
		}

		private void clearComponents() {
			var count = components.Count;
			for (int i = 0; i < count; i++) {
				Destroy(components[i].gameObject);
			}

			components?.Clear();
		}

		private TComponent useItem(T obj) {
			var item = Instantiate(component, container);
			item.SetValue(obj);
			return item;
		}
	}
}