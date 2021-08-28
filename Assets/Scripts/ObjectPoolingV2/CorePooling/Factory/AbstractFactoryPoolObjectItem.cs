using System;
using Core.Factory;
using Core.ObjectPooling;

namespace ObjectPoolingV2.CorePooling.Factory {
	public abstract class AbstractFactoryPoolObjectItem : AbstractFactoryItem, IPoolObject {
		private string factoryName;
		public event UnUseDelegate OnUnUse;

		public Func<bool, bool> OnPooling { get; set; }		
		private string id;

		void IPoolObject.Init(string factoryName) {
			this.factoryName = factoryName;
			id = Guid.NewGuid().ToString();
		}

		public virtual void Activate() {
			gameObject.SetActive(true);
		}

		public virtual void Deactivate() {
			gameObject.SetActive(false);
		}

		public virtual void UnUse() {
			OnUnUse?.Invoke(factoryName, this);
		}

		public bool Contains(IPoolObject poolObject) {
			if (!(poolObject is AbstractFactoryPoolObjectItem factoryPoolObject)) {
				return false;
			}

			return factoryPoolObject.id == id;
		}
		
	}
}