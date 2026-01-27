using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
    public class ItemSpacing : CreditsItem
    {
        private LayoutElement layoutElement;

        protected override void Awake()
        {
            base.Awake();
            layoutElement = GetComponent<LayoutElement>();
        }

        public void SetHeight(float newHeight)
        {
            layoutElement.preferredHeight = newHeight;
        }
    }
}
