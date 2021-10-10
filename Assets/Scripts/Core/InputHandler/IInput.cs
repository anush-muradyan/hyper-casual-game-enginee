using UnityEngine.Events;

namespace Core.InputHandler {
    public interface IInput {
        UnityEvent OnTouch { get; }
    }
}