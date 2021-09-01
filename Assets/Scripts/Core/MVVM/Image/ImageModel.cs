using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.MVVM.Image
{
    public class ImageModel : IModel
    {
        private Texture2D imagePrefab;
        
         public Texture2D ImagePrefab
         {
             get => imagePrefab;
             set
             {
                 imagePrefab = value;
                 PropertyChange(nameof(ImagePrefab), value);
             }
         }
         
         public event PropertyChangeDelegate OnPropertyChange;
        
         public void PropertyChange(string propertyName, object value)
         {
             if (propertyName == null)
             {
                 throw new Exception("Invalid property");
             }
        
             OnPropertyChange?.Invoke(propertyName, value);
         }
        
         public void ForceUpdate()
         {
         }
    }
}