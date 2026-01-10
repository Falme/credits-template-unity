using UnityEngine;
using UnityEngine.UI;

namespace FalmeStreamless.Credits
{
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

        private CanvasScaler canvasScaler;
        private CreditsData data;

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
