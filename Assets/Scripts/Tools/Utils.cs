using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools
{
    public class Utils
    {
        public static List<TCast>  GetInterfaces<T, TCast>() where TCast : class
        {
            var objects = Object.FindObjectsOfType<MonoBehaviour>();
            var holder = new List<TCast>();

            for (int i = 0; i < objects.Length; i++)
            {
                var components = objects[i].GetComponents<T>();
                if (components == null || components.Length==0)
                {
                    continue;
                }

                foreach (var component in components)
                {
                    if (!(component is TCast cmp) || holder.Contains(cmp))
                    {
                        continue;
                    }
                    holder.Add(cmp);
                }
                
            }
            
            return holder;
        }
    }

    
}