using UnityEngine;
using System;

namespace FalmeStreamless.Credits
{
    [ExecuteAlways]
    public class CreditsEnd : MonoBehaviour
    {
        public static event Action onCreditEndReached;

        private RectTransform rectTransform;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (hasReachedTopBorder())
                onCreditEndReached?.Invoke();
        }

        public bool hasReachedTopBorder() => rectTransform.position.y > Screen.height;
    }
}
