using UnityEngine;
using TMPro;

namespace FalmeStreamless.Credits
{
    public class ItemActor : MonoBehaviour
    {
        private TextMeshProUGUI label;
        private RectTransform rectTransform;
        private Pool pool;
        private float lastYPosition;

        void Awake()
        {
            label = GetComponent<TextMeshProUGUI>();
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (hasPassedTopBorder())
                this.pool.ReleaseActor(this);

            lastYPosition = rectTransform.position.y;
        }

        public void SetPool(Pool pool)
        {
            this.pool = pool;
        }

        public void SetText(string newText)
        {
            label.text = newText;
        }

        public bool hasPassedTopBorder()
        {
            bool previousPositionBelowTopBorder =
                (lastYPosition - GetHeight()) <= Screen.height;
            bool currentPositionAboveTopBorder =
                (rectTransform.position.y - GetHeight()) > Screen.height;

            return previousPositionBelowTopBorder && currentPositionAboveTopBorder;
        }

        public float GetHeight()
        {
            return rectTransform.sizeDelta.y;
        }

        public Vector2 BottomItemPosition()
        {
            return (Vector2)rectTransform.position - rectTransform.sizeDelta;
        }
    }
}
