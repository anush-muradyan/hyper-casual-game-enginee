using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.InputHandler {
    [Serializable]
    public class KeyboardInput :IInput,ITickable {
        [SerializeField] private KeyCode keyCode;
        public UnityEvent OnTouch { get; } = new UnityEvent();
        public void Tick() {
            if (Input.GetKeyDown(keyCode)) {
                OnTouch?.Invoke();
            }
        }
    }
}