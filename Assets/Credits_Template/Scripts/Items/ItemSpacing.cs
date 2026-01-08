using UnityEngine;
using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
    public class ItemSpacing : MonoBehaviour, ICreditsItem
    {
        private LayoutElement layoutElement;

        void Awake()
        {
            layoutElement = GetComponent<LayoutElement>();
        }

        public void AutoConfigure(CreditsItem item)
        {
            layoutElement.preferredHeight = item.space;
        }
    }
}
