using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVVM.Command.Image {
	public class LoadTexturesCommand : ICommand<List<Texture2D>> {
		private event Action<List<Texture2D>> callbacks;

		public bool CanExecute(List<Texture2D> data) {
			return true;
		}

		public void Execute(List<Texture2D> data) {
			if (!CanExecute(data)) {
				return;
			}

			callbacks?.Invoke(data);
		}

		public void Subscribe(Action<List<Texture2D>> callback) {
			callbacks += callback;
		}
	}
}