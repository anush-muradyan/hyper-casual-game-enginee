using Core.View.Factory;
using UnityEngine;

namespace Core.View
{
    public class ViewManager : MonoBehaviour, IViewManager<ViewConfig>
    {
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private string viewPath;
        [SerializeField]
        private GameSelectorViewModel gameSelectorViewModel;

         private void construct(GameSelectorViewModel gameSelectorViewModel)
        {
            this.gameSelectorViewModel = gameSelectorViewModel;
         }
        public void Startup()
        {
            gameSelectorViewModel.showGameSelectorView();
        }

        public ViewConfig GetConfig()
        {
            return new ViewConfig(viewPath, viewContainer);
        }
       
    }
}