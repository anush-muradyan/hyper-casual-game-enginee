using UnityEngine;

namespace Games {
    public abstract class BaseGameController : MonoBehaviour, IGamePlay {
        public virtual void StartGame() {
        }

        public virtual void RestartGame() {
        }

        public virtual void Show() {
        }

        public virtual void Quit() {
        }
    }
}