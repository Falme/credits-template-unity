using UnityEngine;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class CreditsScroll : MonoBehaviour
    {
        private float scrollVelocity;

        [Header("Prefab Items")]
        private GameObject itemTitle;

        private CreditsData data;
        private RectTransform rectTransform;
        private bool isScrolling = false;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Initialize(Vector2 resolution, CreditsData data)
        {
            this.data = data;
            FillCreditsData(data);
            ScrollToStart(resolution);
            StartScrolling();
        }

        void Update()
        {
            if (isScrolling)
                Scroll(Time.deltaTime);
        }

        private void FillCreditsData(CreditsData data)
        {
            scrollVelocity = data.velocity;
        }

        public void Scroll(float delta)
        {
            ScrollAdd(scrollVelocity * delta);
        }

        public void StartScrolling()
        {
            isScrolling = true;
        }

        public void StopScrolling()
        {
            isScrolling = false;
        }

        public void ScrollTo(float y)
        {
            rectTransform.anchoredPosition = new Vector2(0, y);
        }

        public void ScrollAdd(float y)
        {
            y = rectTransform.anchoredPosition.y + y;
            rectTransform.anchoredPosition = new Vector2(0, y);
        }

        public void ScrollToStart(Vector2 resolution)
        {
            rectTransform.anchoredPosition = new Vector2(0, -resolution.y);
        }
    }
}
