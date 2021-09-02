using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVVM.Command.Image {
	public class LoadTexturesCommand :ICommand<List<Texture2D>> {
		private Action<List<Texture2D>> executor;

		public LoadTexturesCommand(Action<List<Texture2D>> executor) {
			this.executor = executor;
		}
		public void Execute(List<Texture2D> data) {
			executor?.Invoke(data);
		}
	}
}