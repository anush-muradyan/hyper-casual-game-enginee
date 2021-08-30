using Core.Data;
using DG.Tweening;
using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Factory.ConcreteFactoryPoolObjectItem
{ 
    public class Enemy : AbstractFactoryPoolObjectItem
    {
        [SerializeField] private ScreenSize screenSize;
        public virtual void Awake()
        {
            OnPooling = OnPoolingFunction;
           
          //  transform.DOMove(5 * Vector3.down, 2f).SetLoops(-1);

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
