using UnityEngine;
using System.Collections;

namespace FalmeStreamless.Credits
{
    public class Staff : MonoBehaviour
    {
        [Header("Prefab Items")]
        [SerializeField] private GameObject itemTitle;
        [SerializeField] private GameObject itemCategory;
        [SerializeField] private GameObject itemActor;
        [SerializeField] private GameObject itemSpacing;
        [SerializeField] private GameObject itemImage;

        public void Initialize(CreditsData data)
        {
            Clear();
            WriteTitle(data.title);
            StartCoroutine(WriteStaff(data.items));
        }

        private void Clear()
        {
            while (transform.childCount > 0)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }

        private void WriteTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return;

            ItemLabel label = Instantiate(itemTitle, transform).GetComponent<ItemLabel>();
            label.SetText(title);
        }

        private IEnumerator WriteStaff(CreditsItem[] items)
        {
            for (int item = 0; item < items.Length; item++)
            {
                if (items[item].category) WriteCategory(items[item]);
                else if (items[item].space) WriteSpacing(items[item].height);
                else if (items[item].image) WriteImage(items[item]);
                yield return null;
            }
        }

        private void WriteCategory(CreditsItem category)
        {
            ItemCategory label = Instantiate(itemCategory, transform).GetComponent<ItemCategory>();
            label.onDrawSpace += WriteSpacing;
            label.onDrawActor += WriteActor;

            label.Initialize(category);

            label.onDrawSpace -= WriteSpacing;
            label.onDrawActor -= WriteActor;
        }

        private void WriteActor(string actor)
        {
            if (string.IsNullOrEmpty(actor)) return;

            ItemLabel label = Instantiate(itemActor, transform).GetComponent<ItemLabel>();
            label.SetText(actor);
        }

        private void WriteSpacing(float height)
        {
            ItemSpacing space = Instantiate(itemSpacing, transform).GetComponent<ItemSpacing>();
            space.SetHeight(height);
        }

        private void WriteImage(CreditsItem image)
        {
            ItemImage item = Instantiate(itemImage, transform).GetComponent<ItemImage>();
            item.Initialize(image);
        }
    }
}
