using TMPro;

namespace FalmeStreamless.Credits
{
    public class ItemTitle : CreditsItem
    {
        private TextMeshProUGUI label;

        protected override void Awake()
        {
			base.Awake();
            label = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string newText)
        {
            label.text = newText;
        }
    }
}
