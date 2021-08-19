using Core.Game;
using UnityEngine;

namespace Core.Factory
{
    public class GameFactory:MonoBehaviour
    {
        [SerializeField] private GameItem gameItemPrefab;
        [SerializeField] private RectTransform container;
        
        public GameInfo Create(string name,string info)
        {
            return new GameInfo(name, info);
        }

       public GameItem CreatGameItem()
       {
           return Instantiate(gameItemPrefab, container);
       }
        
    }
}