using System;
using Games;
using UnityEngine;
using Zenject;

namespace Core.InputHandler {
    public enum GameInputType {
        Mouse,
        Keyboard,
        Mobile
    }

    [Serializable]
    public class GameInput {
        [SerializeField] private GameInputType inputType;
        [SerializeField] private MouseInput mouseInput;
        [SerializeField] private KeyboardInput keyboardInput;

        public void BindInput(DiContainer container) {
            switch (inputType) {
                case GameInputType.Mouse:
                    container.BindInterfacesTo<MouseInput>().FromInstance(mouseInput).AsSingle().NonLazy();
                    break;
                case GameInputType.Keyboard:
                    container.BindInterfacesTo<KeyboardInput>().FromInstance(mouseInput).AsSingle().NonLazy();
                    break;
                case GameInputType.Mobile:
                    container.BindInterfacesTo<MobileInput>().AsSingle().NonLazy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}