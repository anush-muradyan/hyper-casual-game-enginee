using System;
using System.Runtime.CompilerServices;
using Core.MVVM.View;
using UnityEngine;

namespace Core.MVVM.Home
{
    public delegate void PropertyChangeDelegate(string propertyName, object obj);

    public class HomeModel : IModel
    {
        private string contentText;

        private readonly ObservableList<Texture2D> textures = new ObservableList<Texture2D>();


        public string ContentText
        {
            get => contentText;
            set
            {
                contentText = value;
                PropertyChange(ContentText);
            }
        }

        public ObservableList<Texture2D> Textures => textures;

        public event PropertyChangeDelegate OnPropertyChange;

        public HomeModel()
        {
            Textures.OnCollectionModify += collection => { PropertyChange(collection, nameof(Textures)); };
        }

        private void PropertyChange<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new Exception("Invalid Property");
            }

            OnPropertyChange?.Invoke(propertyName, value);
        }

        public void ForceUpdate()
        {
            var type = GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var value = propertyInfo.GetValue(this);
                PropertyChange(value, propertyInfo.Name);
            }
        }
        
    }
}