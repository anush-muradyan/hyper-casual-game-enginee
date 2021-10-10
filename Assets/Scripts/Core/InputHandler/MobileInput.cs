using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.InputHandler {
    public class MobileInput : IInput, ITickable {
        public UnityEvent OnTouch { get; } = new UnityEvent();

        public void Tick() {
            if (Input.touchCount > 0) {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    OnTouch?.Invoke();
                }
            }
        }
    }
}