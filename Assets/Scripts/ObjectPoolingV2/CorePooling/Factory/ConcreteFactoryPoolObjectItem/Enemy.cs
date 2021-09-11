namespace ObjectPoolingV2.CorePooling.Factory.ConcreteFactoryPoolObjectItem
{ 
    public class Enemy : AbstractFactoryPoolObjectItem
    {
        public virtual void Awake()
        {
            OnPooling = OnPoolingFunction;
        }
        
        public bool OnPoolingFunction(bool canPlay)
        {
            canPlay = false;
            return canPlay;
        }
    }
}
