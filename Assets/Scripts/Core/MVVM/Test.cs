using System;
using Core.MVVM.Home;
using UnityEngine;

namespace Core.MVVM {
	public class Test : MonoBehaviour {
		[SerializeField] private HomeView homeView;

		private void Start() {
			homeView.Init(new HomeModel { ContentText = "Hello!" });
		}
	}
}