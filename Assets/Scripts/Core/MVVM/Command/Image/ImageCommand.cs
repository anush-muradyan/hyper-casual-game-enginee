using System;
using UnityEngine;

namespace Core.MVVM.Command.Image
{
    public class ImageCommand:ICommand<Texture2D>
    {
        private event Action<Texture2D> callbacks;
        public bool CanExecute()
        {
            return true;
        }
        
        public void Execute(Texture2D data)
        {
            if (!CanExecute()) {
                return;
            }

            callbacks?.Invoke(data);
        }

        public void Subscribe(Action<Texture2D> callback)
        {
            callbacks += callback;
        }
    }
}