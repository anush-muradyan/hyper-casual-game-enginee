using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Factory.ConcreteFactoryPoolObjectItem
{ 
    public class Enemy : AbstractFactoryPoolObjectItem {
        public virtual void Awake()
        {
            OnPooling = OnPoolingFunction;
        }

        public virtual void Update()
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5f);
        }

        public bool  OnPoolingFunction(bool canPlay)
        {
            canPlay = false;
            return canPlay;
        }
    }
}
