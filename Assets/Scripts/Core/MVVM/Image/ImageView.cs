using Core.MVVM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MVVM.Image
{
    public class ImageView : View<ImageViewModel, ImageModel>
    {
        [SerializeField] private RectTransform imageContainer;
        [SerializeField] private UnityEngine.UI.Image imagePrefab;
        [SerializeField] private ImageComponent imageComponent;
        
        [SerializeField] private Button imageSetterButton;
        [SerializeField] private Button deleteImageButton;
        [SerializeField] private Button addImageButton;
        
        private bool setImages;

        private void Start()
        {
            setButtonState(false);
           
            imageSetterButton.onClick.AddListener(setImageButtonClick);
            deleteImageButton.onClick.AddListener(deleteImage);
            addImageButton.onClick.AddListener(addImage);
        }

        protected override void Bind()
        {
            base.Bind();
            Controls.Add(imageComponent);
        }


        private void setImageButtonClick()
        {
            setImages = true;
            setButtonState(true);
            ViewModel.OnNotify?.Invoke(imagePrefab, imageContainer);
            imageSetterButton.gameObject.SetActive(false);
        }

        private void deleteImage()
        {
            ViewModel.OnDeleteImage?.Invoke();
        }

        private void addImage()
        {
            ViewModel.OnAddImage?.Invoke(imagePrefab, imageContainer);
        }

        private void setButtonState(bool state)
        {
            deleteImageButton.gameObject.SetActive(state);
            addImageButton.gameObject.SetActive(state);
        }

        protected override void Disposing()
        {
            base.Disposing();
            imageSetterButton.onClick.RemoveListener(setImageButtonClick);
            deleteImageButton.onClick.RemoveListener(deleteImage);
            addImageButton.onClick.RemoveListener(addImage);
        }
    }
}