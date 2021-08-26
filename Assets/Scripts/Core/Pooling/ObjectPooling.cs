using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Core.Pooling
{
    public class ObjectPooling : MonoBehaviour
    {
        public Dictionary<string, Queue<GameObject>> PoolDictionary;

        public List<Pool> pools;
        private int count;
        private const int capacity = 5;
        private Queue<GameObject> objectPool;

        private void Start()
        {
           initializePoolDictionary();
        }

        public void initializePoolDictionary()
        {
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (var pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                PoolDictionary.Add(pool.prefab.name, objectPool);
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }
        }
        
        public GameObject SpawnToPool<T>()
        {
            var name = typeof(T).Name;
            
            if (!PoolDictionary.ContainsKey(name))
            {
                Debug.LogError("That pool with name " + name + " doesnt exist.");
                return null;
            }

            if (PoolDictionary[name].IsEmpty())
            {
                var pool = pools.FirstOrDefault(pool => pool.prefab.name.Equals(name));
                for (int i = 0; i < capacity; i++)
                {
                    GameObject poolingObject = Instantiate(pool.prefab);
                    poolingObject.SetActive(false);
                    PoolDictionary[name].Enqueue(poolingObject);
                    
                }
            }
            
            var obj = PoolDictionary[name].Dequeue();
            obj.SetActive(true);
            return obj;
            
        }
        
        
        public void BackToPool(GameObject poolingUnit)
        {
             string key = poolingUnit.gameObject.name.Split('(')[0];
             
             poolingUnit.SetActive(false);
             PoolDictionary[key].Enqueue(poolingUnit);
        }
        
    }
}
