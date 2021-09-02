using System;
using System.Collections.Generic;
using System.Linq;
using Core.MVVM.Controls;
using UnityEngine;

namespace Core.MVVM
{
    public abstract class View<TViewModel, TModel> : MonoBehaviour, IDisposable, IView
        where TViewModel : IViewModel<TModel>, new() where TModel : IModel
    {
        public TViewModel ViewModel { get; private set; }

        protected List<ComponentControl> Controls = new List<ComponentControl>();
        private bool isdisposed;
        public void Init(TModel model)
        {
            ViewModel = new TViewModel {Model = model};
            ViewModel.Init();
            Bind();
            ViewModel.Model.OnPropertyChange += PropertyChange;
            ViewModel.Model.ForceUpdate();
        }

        protected virtual void Bind()
        {
        }
        
        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnDestroy()
        {
            ((IDisposable)(this)).Dispose();
        }

        private void PropertyChange(string propertyName, object obj)
        {
            var component = Controls.SingleOrDefault(
                control => control.PropertyName.Equals(propertyName));
            if (component == null)
            {
                Debug.LogError("Componenet is null.");
                return;
            }

            component.SetValue(obj);
        }
        void IDisposable.Dispose()
        {
            Disposing();
        }

        protected virtual void Disposing()
        {
            if (isdisposed)
            {
                return;
            }
            ViewModel.Model.OnPropertyChange -= PropertyChange;
            isdisposed = true;
        }
    }
}