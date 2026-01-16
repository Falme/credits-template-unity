using UnityEngine;
using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
    public class ItemImage : MonoBehaviour
    {
        private Image image;
        private LayoutElement layoutElement;

        void Awake()
        {
            image = GetComponent<Image>();
            layoutElement = GetComponent<LayoutElement>();
        }

        public void SetImage(string path)
        {
            string streamingPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
            byte[] pngBytes = System.IO.File.ReadAllBytes(streamingPath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);
            Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            image.sprite = fromTex;
        }

        public void SetHeight(float height)
        {
            layoutElement.preferredHeight = height;
        }
    }
}
