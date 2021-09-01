using Core.MVVM.Command;
using Core.MVVM.Command.Image;
using UnityEngine;
using UnityEngine.Events;

namespace Core.MVVM.Image
{
    public class ImageViewModel : IViewModel<ImageModel>
    {
        public UnityEvent<UnityEngine.UI.Image, RectTransform> OnNotify =
            new UnityEvent<UnityEngine.UI.Image, RectTransform>();

        public ImageModel Model { get; set; }

        public ICommand<Texture2D> UpdateImageSetterCommand { get; }
        
        public ImageViewModel()
        {
           
            UpdateImageSetterCommand = new ImageCommand();
            OnNotify.AddListener(LoadPrefabs);
        }

        private void LoadPrefabs(UnityEngine.UI.Image prefab, RectTransform container)
        {
            var images = Resources.LoadAll<Texture2D>("Textures");

            for (int i = 0; i < images.Length; i++)
            {
                var image = Object.Instantiate(prefab, container);
                Debug.Log(image.sprite.name);
                UpdateImageSetterCommand.Execute(images[i]);

            }
        }

        public void Init()
        {
            UpdateImageSetterCommand.Subscribe(data => Model.ImagePrefab = data);
        }
    }
}