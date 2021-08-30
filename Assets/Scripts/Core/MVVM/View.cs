using System;
using System.Collections.Generic;
using System.Linq;
using Core.MVVM.Controls;
using UnityEngine;

namespace Core.MVVM {
	public abstract class View<TViewModel, TModel> : MonoBehaviour, IDisposable, IView
		where TViewModel : IViewModel<TModel>, new() where TModel : IModel {
		public TViewModel ViewModel { get; private set; }

		protected List<StaticComponentControl> Controls = new List<StaticComponentControl>();

		public void Init(TModel model) {
			ViewModel = new TViewModel { Model = model };
			Bind();
			ViewModel.Model.OnPropertyChange += PropertyChange;
			ViewModel.Model.ForceUpdate();
		}

		public virtual void Bind() {
		}


		protected virtual void OnEnable() {
		}

		protected virtual void OnDisable() {
		}

		protected virtual void OnDestroy() {
			Dispose();
		}

		private void PropertyChange(string propertyName, object obj) {
			var component = Controls.SingleOrDefault(control => control.PropertyName.Equals(propertyName));
			if (component == null) {
				return;
			}

			component.SetValue(obj);
		}

		public void Dispose() {
			ViewModel.Model.OnPropertyChange -= PropertyChange;
		}
	}
}