using TMPro;
using System;

namespace FalmeStreamless.Credits
{
    public class ItemCategory : CreditsItem
    {
        public event Action<float> onDrawSpace;
        public event Action<string> onDrawActor;
        private TextMeshProUGUI label;

        protected override void Awake()
        {
            base.Awake();
            label = GetComponent<TextMeshProUGUI>();
        }

        public void Initialize(CreditsItemData category)
        {
            SetText(category.text);
            // SetCategorySpacing(category);
            // SetActors(category);
        }

        private void SetText(string newText)
        {
            label.text = newText;
        }

        private void SetCategorySpacing(CreditsItemData category)
        {
            if (category.categorySpacing > 0f)
                onDrawSpace?.Invoke(category.categorySpacing);
        }

        private void SetActors(CreditsItemData category)
        {
            for (int a = 0; a < category.actors.Length; a++)
            {
                onDrawActor?.Invoke(category.actors[a]);

                if (category.actorsSpacing > 0f)
                    onDrawSpace?.Invoke(category.actorsSpacing);
            }
        }
    }
}
