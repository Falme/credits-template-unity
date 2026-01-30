using UnityEngine;

namespace FalmeStreamless.Credits
{
    public abstract class CreditsItem : MonoBehaviour
    {
        protected RectTransform rectTransform;
        protected Pool pool;
        protected float lastYPosition;

        protected virtual void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        protected virtual void Update()
        {
            if (hasPassedTopBorder())
                this.pool.Release(this);

			// if (hasPassedBottomBorder())
			// 	GetComponentInParent<Staff>().DequeueItem();

            lastYPosition = rectTransform.position.y;
        }

        public void SetPool(Pool pool)
        {
            this.pool = pool;
        }

        public bool hasPassedTopBorder()
        {
            bool previousPositionBelowTopBorder =
                (lastYPosition - (GetHeight() / 2)) <= Screen.height;
            bool currentPositionAboveTopBorder =
                (rectTransform.position.y - (GetHeight() / 2)) > Screen.height;

            return previousPositionBelowTopBorder && currentPositionAboveTopBorder;
        }

		public bool hasPassedBottomBorder()
		{
            // bool previousPositionBelowBottomBorder =
            //     (lastYPosition - (GetHeight() / 2)) <= 0;
            // bool currentPositionAboveBottomBorder =
            //     (rectTransform.position.y - (GetHeight() / 2)) > 0;
            //
            // return previousPositionBelowBottomBorder && currentPositionAboveBottomBorder;
            return (rectTransform.position.y - (GetHeight() / 2)) > 0;
		}

        public float GetHeight() => rectTransform.sizeDelta.y;
    }
}
