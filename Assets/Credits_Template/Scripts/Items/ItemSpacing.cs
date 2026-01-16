using UnityEngine;
using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
    public class ItemSpacing : MonoBehaviour
    {
        private LayoutElement layoutElement;

        void Awake()
        {
            layoutElement = GetComponent<LayoutElement>();
        }

        public void SetHeight(float newHeight)
        {
            layoutElement.preferredHeight = newHeight;
        }
    }
}
