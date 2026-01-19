using UnityEngine;
using TMPro;
using System;

namespace FalmeStreamless.Credits
{
    public class ItemCategory : MonoBehaviour
    {
        public event Action<float> onDrawSpace;
        public event Action<string> onDrawActor;
        private TextMeshProUGUI text;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void Initialize(CreditsItem category)
        {
            SetText(category.text);
            SetCategorySpacing(category);
            SetActors(category);
        }

        private void SetText(string newText)
        {
            this.text.text = newText;
        }

        private void SetCategorySpacing(CreditsItem category)
        {
            if (category.categorySpacing > 0f)
                onDrawSpace?.Invoke(category.categorySpacing);
        }

        private void SetActors(CreditsItem category)
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
