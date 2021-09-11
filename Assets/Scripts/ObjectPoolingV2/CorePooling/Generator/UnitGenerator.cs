using Core.Data;
using Core.ObjectPooling;
using DG.Tweening;
using ObjectPoolingV2.CorePooling.Factory;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace ObjectPoolingV2.CorePooling.Generator {
    public class UnitGenerator<T> : AbstractGenerator<T> where T : AbstractFactoryPoolObjectItem {
        [SerializeField] private int minRotationRange;
        [SerializeField] private int maxRotationRange;

        [SerializeField] private float moveEndValue = 3f;
        [SerializeField] private float moveDuration = 1.5f;
        [SerializeField] private float rotateDuration = 1f;
        [SerializeField] private float rotateDuringFall = 70;
        private ScreenSize screenSize;

        [Inject]
        private void construct(ScreenSize screenSize) {
            this.screenSize = screenSize;
        }

        public override IPoolObject Generate() {
            var item = Use();
            var angle = Random.Range(minRotationRange, maxRotationRange);

            item.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
            item.transform.position = new Vector3(0f, Mathf.Abs(screenSize.Size.y), 0f);
            item.transform.DOMove(-item.transform.up * moveEndValue, moveDuration).SetEase(Ease.Linear);
            item.transform.DOLocalRotate(Vector3.forward * rotateDuringFall, rotateDuration);

            return item;
        }
    }
}