using UnityEngine;

namespace AbstractFactory.Factory
{
    public abstract class AbstractFactory : MonoBehaviour
        {
        }

        public abstract class AbstractFactory<TProduct> : AbstractFactory where TProduct : IAbstractProduct
        {
            public abstract TConcrete Create<TConcrete>() where TConcrete : TProduct;
        }

        public abstract class AbstractFactoryFromResource<TProduct> : AbstractFactory where TProduct : IAbstractProduct
        {
            public abstract TConcrete Create<TConcrete>() where TConcrete : Object, TProduct;
        }

        public class FactoryFromResource<TProduct> : AbstractFactoryFromResource<TProduct> where TProduct : IAbstractProduct
        {
            [SerializeField] private string folderName;

            public sealed override TConcrete Create<TConcrete>()
            {
                var prefabName = typeof(TConcrete).Name;
                Debug.Log(prefabName);
                var path = $"{folderName}/{prefabName}";
                var productPrefab = Resources.Load<TConcrete>(path);
                Debug.LogError(productPrefab);
                var product = Instantiate(productPrefab);
                return product;
            }
        }
    
}