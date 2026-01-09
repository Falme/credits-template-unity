using UnityEngine;

namespace FalmeStreamless.Credits
{
    public class Credits : MonoBehaviour
    {
        [Header("All Credits Data")]
        [SerializeField] private TextAsset creditsJSON;

        [Header("Transforms/UI")]
        [SerializeField] private Transform creditsScroll;

        [Header("Elements/Prefabs")]
        [SerializeField] private GameObject start;
        [SerializeField] private GameObject end;
        [SerializeField] private GameObject spacing;

        private CreditsData data;

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
