using Core.Factory;
using UnityEngine;

namespace ObjectPoolingV2.Core.Factory {
	public class AbstractFactory : MonoBehaviour {
		[SerializeField] private AbstractFactoryItem factoryItem;
		[SerializeField] private Transform container;
		[SerializeField] private int defaultCapacity = 5;

		public string FactoryName => gameObject.name;

		public int DefaultCapacity => defaultCapacity;

		public virtual AbstractFactoryItem Create() {
			return Instantiate(factoryItem, container);
		}
	}
}