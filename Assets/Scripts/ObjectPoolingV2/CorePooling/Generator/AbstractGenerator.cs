using Core.ObjectPooling;
using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Generator
{
	public abstract class AbstractGenerator<T> : MonoBehaviour where T : class, IPoolObject
	{
		[SerializeField] private PoolManager poolManager;
		[SerializeField] private string factoryName;

		
		public abstract IPoolObject Generate();

		protected virtual void Start()
		{
		}

		protected virtual T Use()
		{
			return poolManager.Use<T>(factoryName);
		}


		
	}
}