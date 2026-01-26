using UnityEngine;
using TMPro;

namespace FalmeStreamless.Credits
{
    public class ItemActor : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private RectTransform rectTransform;
        private Pool pool;
        private bool isRolling;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (!isRolling) return;

            if (hasPassedTopBorder())
                this.pool.ReleaseActor(this);
        }

        public void SetPool(Pool pool)
        {
            this.pool = pool;
        }

        public void SetText(string newText)
        {
            this.text.text = newText;
        }

        public bool hasPassedTopBorder()
        {
            float pivotY = rectTransform.position.y - rectTransform.sizeDelta.y;
            return pivotY > Screen.height;
        }

        public float GetHeight()
        {
            return rectTransform.sizeDelta.y;
        }

        public void SetRolling(bool rolling)
        {
            this.isRolling = rolling;
        }
    }
}
