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

        [Header("References")]
        [SerializeReference] private Scroll scroll;

        private CanvasScaler canvasScaler;
        private CreditsData data;

        void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }

        void OnEnable()
        {
            End.onCreditEndReached += CreditEndReached;
        }

        void OnDisable()
        {
            End.onCreditEndReached -= CreditEndReached;
        }

        void Start()
        {
            scroll.Initialize(
                canvasScaler.referenceResolution,
                GetJsonData()
                );
        }

        void CreditEndReached(float difference)
        {
            scroll.StopScrolling();
            scroll.ScrollAdd(-difference); // Fix Overshot position
            creditsFinishedEvent?.Invoke();
        }

        private CreditsData GetJsonData()
        {
            return JsonConvert.DeserializeObject<CreditsData>(creditsJSON.text);
        }

    }
}

