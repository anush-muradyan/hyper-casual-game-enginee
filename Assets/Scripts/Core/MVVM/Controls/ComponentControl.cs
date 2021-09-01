using System;
using UnityEngine;

namespace Core.MVVM.Controls {
	[Serializable]
	public abstract class ComponentControl : MonoBehaviour {
		[SerializeField] private string propertyName;
		public string PropertyName => propertyName;

		public abstract void SetValue(object value);
	}

	[Serializable]
	public abstract class ComponentControl<T> : ComponentControl {
		[SerializeField] private T property;

		public T Property
		{
			get => property;

			set => property = value;
		}
	}
}