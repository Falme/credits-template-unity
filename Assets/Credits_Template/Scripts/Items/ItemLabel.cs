using UnityEngine;
using TMPro;

namespace FalmeStreamless.Credits
{
    public class ItemLabel : MonoBehaviour
    {
        private TextMeshProUGUI text;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string newText)
        {
            this.text.text = newText;
        }
    }
}
