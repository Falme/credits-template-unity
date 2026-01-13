using UnityEngine;

namespace FalmeStreamless.Credits
{
    public class CreditsStaff : MonoBehaviour
    {
        [Header("Prefab Items")]
        [SerializeField] private GameObject itemTitle;

        public void Initialize(CreditsData data)
        {
            Instantiate(itemTitle, transform);
        }

        //ClearStaff();
    }
}
