using Core.MVVM.Home;
using Core.MVVM.Image;
using UnityEngine;

namespace Core.MVVM
{
	public class Test : MonoBehaviour
	{
		[SerializeField] private HomeView homeView;
		[SerializeField] private ImageView imageView;


		private void Start()
		{
			imageView.Init(new ImageModel {});

		}
	}
}