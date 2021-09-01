using Core.MVVM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Image
{
    public class ImageView : View<ImageViewModel, ImageModel>
    {
        
        [SerializeField] private RectTransform imageContainer;
        [SerializeField] private Button imageSetterButton;
        [SerializeField] private UnityEngine.UI.Image imagePrefab;

        [SerializeField] private ImageComponent imageComponent;
        private void Start()
        {
            imageSetterButton.onClick.AddListener(setImageButtonClick);
        }

        public override void Bind()
        {
            base.Bind();
            Controls.Add(imageComponent);
        }


        private void setImageButtonClick()
        {
            var ima = imagePrefab.sprite.texture;
            ViewModel.OnNotify?.Invoke(imagePrefab, imageContainer);
            ViewModel.UpdateImageSetterCommand.Execute(ima);
        }
    }
}