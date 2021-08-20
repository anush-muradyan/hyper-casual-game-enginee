using Core.AbstractFactory;
using Core.Data;
using Core.Game;
using UnityEngine;

namespace Core.Factory
{
    
    public class GameFactory:MonoBehaviour
    {
        [SerializeField] private GameItem gameItemPrefab;
        [SerializeField] private RectTransform container;
        
        
    }
}