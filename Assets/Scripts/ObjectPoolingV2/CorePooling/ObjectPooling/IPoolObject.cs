namespace Core.ObjectPooling {
	public delegate void UnUseDelegate(string factoryName, IPoolObject poolObject);

	public interface IPoolObject {
		event UnUseDelegate OnUnUse;
		void Activate();
		void Deactivate();
		void UnUse();
		void Init(string factoryName);
		bool Contains(IPoolObject poolObject);
	}
}