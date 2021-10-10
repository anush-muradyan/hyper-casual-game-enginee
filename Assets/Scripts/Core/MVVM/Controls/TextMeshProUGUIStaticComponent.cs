using TMPro;

namespace Core.MVVM.Controls {
    public class TextMeshProUGUIStaticComponent : StaticComponentControl<TextMeshProUGUI> {
        public override void SetValue(object value) {
            if (value == null) {
                return;
            }
            var str = value.ToString();
            Property.text = str;
        }
    }
}