using System.Collections.Generic;
using Core.MVVM.Command;
using Core.MVVM.Command.Image;
using UnityEngine;
using UnityEngine.Events;

namespace Core.MVVM.Image
{
    public class ImageViewModel : IViewModel<ImageModel>
    {
        public UnityEvent<UnityEngine.UI.Image, RectTransform> OnNotify = new UnityEvent<UnityEngine.UI.Image, RectTransform>();
        public UnityEvent OnDeleteImage = new UnityEvent();
        
        public UnityEvent<UnityEngine.UI.Image, RectTransform> OnAddImage = new UnityEvent<UnityEngine.UI.Image, RectTransform>();
        private Texture2D[] images= Resources.LoadAll<Texture2D>("Textures");

        public ImageModel Model { get; set; }
        private Stack<UnityEngine.UI.Image> imageStack = new Stack<UnityEngine.UI.Image>();
        public ICommand<Texture2D> UpdateImageSetterCommand { get; }
        
        public ImageViewModel()
        {
            UpdateImageSetterCommand = new ImageCommand();
            OnNotify.AddListener(LoadPrefabs);
            OnDeleteImage.AddListener(deleteImage);
            OnAddImage.AddListener(AddImage);
        }

        private void LoadPrefabs(UnityEngine.UI.Image prefab, RectTransform container)
        {
            for (int i = 0; i < images.Length; i++)
            {
                UpdateImageSetterCommand.Execute(images[i]);
                var image = Object.Instantiate(prefab, container);
                imageStack.Push(image);
            }
        }

        public void Init()
        {
            UpdateImageSetterCommand.Subscribe(data => Model.ImagePrefab = data);
        }

        private void deleteImage()
        {
            if (imageStack.Count.Equals(0))
            {
                return;
            }
            var image = imageStack.Pop(); 
            Object.Destroy(image.gameObject);
        }
        
        private void AddImage(UnityEngine.UI.Image prefab, RectTransform container)
        {
            var randomNumber = Random.Range(0, images.Length);
            UpdateImageSetterCommand.Execute(images[randomNumber]);
            var image = Object.Instantiate(prefab, container);
            imageStack.Push(image);
        }
    }
}