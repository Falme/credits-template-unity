using UnityEngine;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class Credits : MonoBehaviour
    {
        public static event Action creditsFinishedEvent;

        [Header("All Credits Data")]
        [SerializeField] private TextAsset creditsJSON;

        [Header("Elements/Prefabs")]
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
            creditsScroll.Initialize(
                canvasScaler.referenceResolution,
                GetJsonData()
                );
        }

        void CreditEndReached(float difference)
        {
            creditsScroll.StopScrolling();
            creditsScroll.ScrollAdd(-difference); // Fix Overshot position
            creditsFinishedEvent?.Invoke();
        }

        private CreditsData GetJsonData()
        {
            return JsonConvert.DeserializeObject<CreditsData>(creditsJSON.text);
        }

    }
}

