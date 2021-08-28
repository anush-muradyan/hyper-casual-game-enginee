using System.Collections.Generic;
using ModestTree;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;

namespace Core.ObjectPooling {
	public sealed class PoolManager : MonoBehaviour {
		[SerializeField] private FactoryHolder factoryHolder;
		private readonly Dictionary<string, Queue<IPoolObject>> pool = new Dictionary<string, Queue<IPoolObject>>();

		private readonly Dictionary<string, List<IPoolObject>>
			activePool = new Dictionary<string, List<IPoolObject>>();

		public void CreateRange(string factoryName, int count) {
			for (int i = 0; i < count; i++) {
				Create(factoryName);
			}
		}

		public void Create(string factoryName) {
			var factoryItem = factoryHolder.Create(factoryName);
			var poolObject = factoryItem as IPoolObject;
			if (poolObject == null) {
				return;
			}

			poolObject.OnUnUse += UnUse;
			poolObject.Init(factoryName);
			poolObject.Deactivate();
			if (!pool.ContainsKey(factoryName)) {
				pool.Add(factoryName, new Queue<IPoolObject>());
			}

			pool[factoryName].Enqueue(poolObject);
		}

		public T Use<T>(string factoryName) where T : class, IPoolObject {
			if (!pool.ContainsKey(factoryName) || pool[factoryName].Count == 0) {
				var factory = factoryHolder.GetFactory(factoryName);
				if (factory == null) {
					return null;
				}

				CreateRange(factoryName, factory.DefaultCapacity == 0 ? 2 : factory.DefaultCapacity);
				return Use<T>(factoryName);
			}

			var poolObject = pool[factoryName].Dequeue();
			poolObject.Activate();
			if (!activePool.ContainsKey(factoryName)) {
				activePool.Add(factoryName, new List<IPoolObject>());
			}

			activePool[factoryName].Add(poolObject);
			return poolObject as T;
		}

		public void UnUse(string factoryName, IPoolObject poolObject) {
			var activePoolItemIndex = activePool[factoryName]
				.FindIndex(activePoolObject => activePoolObject.Contains(poolObject));
			if (activePoolItemIndex < 0) {
				Debug.LogError("Can't find pool item.");
				return;
			}

			activePool[factoryName].RemoveAt(activePoolItemIndex);
			poolObject.Deactivate();
			pool[factoryName].Enqueue(poolObject);
		}

		public void UnUseAll()
		{
			foreach (var p in activePool)
			{
				var pol = new List<IPoolObject>(p.Value);
				pol.ForEach(o => o.UnUse());
			}

		}
	}
}