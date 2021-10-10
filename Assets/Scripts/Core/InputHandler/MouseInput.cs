using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.InputHandler {
    public enum MouseType {
        Left = 0,
        Right,
        Middle
    }

    [Serializable]
    public class MouseInput : IInput, ITickable {
        [SerializeField] private MouseType type;
        public UnityEvent OnTouch { get; } = new UnityEvent();

        public void Tick() {
            handle();
        }

        private void handle() {
            if (Input.GetMouseButtonDown((int) type)) {
                OnTouch?.Invoke();
            }
        }
    }
}