using UnityEngine;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class CreditsScroll : MonoBehaviour
    {
        [SerializeField] private float scrollVelocity;

        private RectTransform rectTransform;
        private bool isScrolling = false;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Initialize(Vector2 resolution)
        {
            ScrollToStart(resolution);
            StartScrolling();
        }

        void Update()
        {
            if (isScrolling)
                Scroll(Time.deltaTime);
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
