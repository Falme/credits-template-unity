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
            //set image path to be loaded
        }

        public void SetHeight(float height)
        {
            layoutElement.preferredHeight = height;
        }
    }
}
