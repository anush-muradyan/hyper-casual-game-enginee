using UnityEngine;

namespace UI.View
{
    public class AbstractView : MonoBehaviour
    {
        public virtual AbstractView Show()
        {
            gameObject.SetActive(true);
            return this;
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }
    }
}
