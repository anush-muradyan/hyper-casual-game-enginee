using System.Collections.Generic;
using System.Linq;
using Core.Factory;
using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Factory {
	public class FactoryHolder : MonoBehaviour {
		[SerializeField] private List<ObjectPoolingV2.Core.Factory.AbstractFactory> factories;

		public AbstractFactoryItem Create(string factoryName) {
			var factory = GetFactory(factoryName);
			if (factory == null) {
				return null;
			}

			return factory.Create();
		}

		public ObjectPoolingV2.Core.Factory.AbstractFactory GetFactory(string factoryName) {
			var factory = factories.FirstOrDefault(abstractFactory => abstractFactory.FactoryName.Equals(factoryName));
			if (factory == null) {
				Debug.LogError("Can't find factory.");
				return null;
			}

			return factory;
		}
	}
}