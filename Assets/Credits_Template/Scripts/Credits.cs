using UnityEngine;
using UnityEngine.UI;
using System;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class Credits : MonoBehaviour
    {
        public static event Action creditsFinishedEvent;

        [Header("All Credits Data")]
        [SerializeField] private TextAsset creditsJSON;

        [Header("Elements/Prefabs")]
        [SerializeField] private GameObject start;
        [SerializeField] private GameObject end;
        [SerializeField] private GameObject spacing;

        [Header("References")]
        [SerializeReference] private CreditsScroll creditsScroll;
        [SerializeReference] private CreditsEnd creditsEnd;

        private CanvasScaler canvasScaler;
        private CreditsData data;

        void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }

        void OnEnable()
        {
            CreditsEnd.onCreditEndReached += CreditEndReached;
        }

        void OnDisable()
        {
            CreditsEnd.onCreditEndReached -= CreditEndReached;
        }

        void Start()
        {
            creditsScroll.Initialize(canvasScaler.referenceResolution);
        }

        void CreditEndReached(float difference)
        {
            creditsScroll.StopScrolling();
            creditsScroll.ScrollAdd(-difference); // Fix Overshot position
            creditsFinishedEvent?.Invoke();
        }

        // Still not used functions
        private void SerializeJsonData()
        {
            data = JsonUtility.FromJson<CreditsData>(creditsJSON.text);
        }

        private void CreateStartPoint()
        {
            // GameObject.Instantiate(start, creditsScroll);
        }

        private void CreateEndPoint()
        {
            // GameObject.Instantiate(end, creditsScroll);
        }

        private void CreateLabel(CreditsItem item)
        {
            if (item.actors == null) return;
            for (int a = 0; a < item.actors.Length; a++)
                Debug.Log(item.actors[a]);
        }
    }
}
