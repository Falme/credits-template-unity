using UnityEngine;
using TMPro;

namespace FalmeStreamless.Credits
{
    public class ItemActor : CreditsItem
    {
        private TextMeshProUGUI label;

        protected override void Awake()
        {
            base.Awake();
            label = GetComponent<TextMeshProUGUI>();
        }

        protected override void Update()
        {
            if (hasPassedTopBorder())
                this.pool.ReleaseActor(this);

            lastYPosition = rectTransform.position.y;
        }

        public void SetText(string newText)
        {
            label.text = newText;
        }

        public Vector2 BottomItemPosition()
        {
            return (Vector2)rectTransform.position - rectTransform.sizeDelta;
        }
    }
}
