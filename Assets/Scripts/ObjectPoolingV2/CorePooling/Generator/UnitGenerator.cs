using Core.Data;
using Core.ObjectPooling;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;

namespace ObjectPoolingV2.CorePooling.Generator
{
    public class UnitGenerator<T> : AbstractGenerator<T> where T:AbstractFactoryPoolObjectItem
    {
        [SerializeField] private int minRotationRange;
        [SerializeField] private int maxRotationRange;
        [SerializeField] private ScreenSize screenSize;
        
        public override IPoolObject Generate() {
            var item = Use(); 
            
            var angle = Random.Range(minRotationRange, maxRotationRange);
            item.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
            item.transform.position = new Vector3(0f, Mathf.Abs(screenSize.height), 0f);
            
            return item;
        }
     
    }
}