using UnityEngine;
using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class Credits : MonoBehaviour
    {
        [Header("All Credits Data")]
        [SerializeField] private TextAsset creditsJSON;

        [Header("Transforms/UI")]
        [SerializeField] private RectTransform creditsScroll;

        [Header("Elements/Prefabs")]
        [SerializeField] private GameObject start;
        [SerializeField] private GameObject end;
        [SerializeField] private GameObject spacing;

        [Header("Scrolling info")]
        [SerializeField] private float scrollVelocity;

        private CanvasScaler canvasScaler;
        private CreditsData data;

        private bool isScrolling = false;

        void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }

        void Start()
        {
            SerializeJsonData();
            CreateStartPoint();
            for (int a = 0; a < data.credits.Length; a++)
            {
                if (data.credits[a].space > 0)
                {
                    GameObject g = GameObject.Instantiate(spacing, creditsScroll);
                    ICreditsItem item = g.GetComponent<ICreditsItem>();
                    item.AutoConfigure(data.credits[a]);
                }
                else
                {
                    CreateLabel(data.credits[a]);
                }
            }
            CreateEndPoint();
            StartScrolling();
        }

        void Update()
        {
            if (isScrolling)
                Scroll(Time.deltaTime);
        }

        public void ScrollToStart()
        {
            if (canvasScaler == null) canvasScaler = GetComponent<CanvasScaler>();

            float y = -canvasScaler.referenceResolution.y;
            creditsScroll.anchoredPosition = new Vector2(0, y);
        }

        public void ScrollTo(float y)
        {
            creditsScroll.anchoredPosition = new Vector2(0, y);
        }

        public void Scroll(float delta)
        {
            ScrollTo(creditsScroll.anchoredPosition.y + (scrollVelocity * delta));
        }

        public void StartScrolling()
        {
            isScrolling = true;
        }

        public void StopScrolling()
        {
            isScrolling = false;
        }

        private void SerializeJsonData()
        {
            data = JsonUtility.FromJson<CreditsData>(creditsJSON.text);
        }

        private void CreateStartPoint()
        {
            GameObject.Instantiate(start, creditsScroll);
        }

        private void CreateEndPoint()
        {
            GameObject.Instantiate(end, creditsScroll);
        }

        private void CreateLabel(CreditsItem item)
        {
            if (item.actors == null) return;
            for (int a = 0; a < item.actors.Length; a++)
                Debug.Log(item.actors[a]);
        }
    }
}
