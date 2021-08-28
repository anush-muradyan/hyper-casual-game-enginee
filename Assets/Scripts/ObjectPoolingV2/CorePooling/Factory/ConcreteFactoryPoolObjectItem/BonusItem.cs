using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Factory.ConcreteFactoryPoolObjectItem
{
    public class BonusItem : AbstractFactoryPoolObjectItem
    {
        public virtual void Awake()
        {
            OnPooling = OnPoolingFunction;
        }
        
        public bool OnPoolingFunction(bool addScore)
        {
            addScore = true;
            return addScore;
        }
        
        public virtual void Update()
            {
                transform.Translate(Vector3.down * Time.deltaTime * 5f);
            }
        }
    }

