using UnityEngine;
using UnityEngine.Assertions;

namespace Croccen {
    public class Properties : MonoBehaviour {
        private const string _skinPath = "Materials/Croccen/Skin";

        // TODO croccen accessories array
        public Croccen.Color color;
        public Croccen.Size size;

        private Renderer _renderer;

        public Properties(Croccen.Color color, Croccen.Size size) {
            this.color = color;
            this.size = size;
        }

        public void Start() {
            _renderer = GetComponent<Renderer>();
            Assert.IsNotNull(_renderer);
            if (color == null)
                color = Color.Grey;
            SetColor(color);
            if (size == null)
                size = Size.Baby;
            SetSize(size);
        }

        public void SetSize(Croccen.Size newSize) {
            transform.localScale = newSize.value;
            size = newSize;
        }

        public void SetColor(Croccen.Color newColor) {
            string skin = _skinPath + "/" + newColor.name;
            Material material = Resources.Load<Material>(skin);
            Assert.IsNotNull(material);
            _renderer.sharedMaterial = material;
            color = newColor;
        }
    }
}