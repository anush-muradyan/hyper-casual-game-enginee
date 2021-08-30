using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.MVVM.Command.Home {
	public class ResourceCollectionCommand<TResource> : ICommand where TResource : Object {
		private readonly string path;
		private readonly Action<IEnumerable<TResource>> executor;

		public ResourceCollectionCommand(string path, Action<IEnumerable<TResource>> executor) {
			this.path = path;
			this.executor = executor;
		}

		public void Execute() {
			var collection = Resources.LoadAll<TResource>(path);
			executor?.Invoke(collection);
		}
	}
}