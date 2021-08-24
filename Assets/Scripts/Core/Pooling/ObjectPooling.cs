using System.Collections.Generic;
using System.Linq;
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

        public GameObject SpawnToPool(string name)
        {
            if (!PoolDictionary.ContainsKey(name))
            {
                Debug.LogError("That pool with name " + name + " doesnt exist.");
                return null;
            }

            foreach (var obj in PoolDictionary[name])
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            var pool = pools.FirstOrDefault(pool => pool.prefab.name.Equals(name));
            for (int i = 0; i < capacity; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                PoolDictionary[name].Enqueue(obj);
            }

            return SpawnToPool(name);
        }

        public void BackToPool(string name)
        {
            if (!PoolDictionary.ContainsKey(name))
            {
                Debug.LogError("That pool with name " + name + " doesnt exist.");
                return;
            }

            foreach (var obj in PoolDictionary[name])
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                    PoolDictionary[name].Enqueue(obj);
                    return;
                }
            }
        }
        
    }
}
