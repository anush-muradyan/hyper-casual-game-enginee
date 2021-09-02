using Core.View.Factory;
using UnityEngine;

namespace Core.View
{
    public class ViewManager : MonoBehaviour, IViewManager<ViewConfig>
    {
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private string viewPath;
  
        public void Startup()
        {
        }

        public ViewConfig GetConfig()
        {
            return new ViewConfig(viewPath, viewContainer);
        }
       
    }
}