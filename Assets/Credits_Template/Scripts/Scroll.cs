using UnityEngine;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class Scroll : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Staff staff;

        private RectTransform rectTransform;
        private float velocity;
        private bool isScrolling;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (isScrolling)
                ScrollCredits(Time.deltaTime);
        }

        public void Initialize(Vector2 resolution, CreditsData data)
        {
            FillCreditsData(data);
            ScrollToStart(resolution);
            StartScrolling();
        }

        private void FillCreditsData(CreditsData data)
        {
            velocity = data.velocity;
            staff.Initialize(data);
        }

        public void ScrollToStart(Vector2 resolution)
        {
            rectTransform.anchoredPosition = new Vector2(0, -resolution.y);
        }

        public void ScrollCredits(float delta)
        {
            ScrollAdd(velocity * delta);
        }

        public void StartScrolling()
        {
            isScrolling = true;
        }

        public void StopScrolling()
        {
            isScrolling = false;
        }

        public void ScrollAdd(float y)
        {
            y += rectTransform.anchoredPosition.y;
            rectTransform.anchoredPosition = new Vector2(0, y);
        }
    }
}
