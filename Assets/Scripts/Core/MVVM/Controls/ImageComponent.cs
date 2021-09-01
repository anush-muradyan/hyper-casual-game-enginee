using UnityEngine;

namespace Core.MVVM.Controls
{
    public class ImageComponent : ComponentControl<UnityEngine.UI.Image>
    {
        public override void SetValue(object value)
        {
            Debug.Log("From Set Value");
            var texture = (Texture2D) value;
            if (texture == null)
            {
                return;
            }

            var sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.one * 0.5f);
            Property.sprite = sprite;
        }
    }
}