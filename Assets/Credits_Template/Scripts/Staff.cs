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
            ClearStaff();
            WriteTitle(data.title);
            StartCoroutine(WriteStaff(data.items));
        }

        private void ClearStaff()
        {
            while (transform.childCount > 0)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }

        private void WriteTitle(string title)
        {
            ItemLabel label = Instantiate(itemTitle, transform).GetComponent<ItemLabel>();
            label.SetText(title);
        }

        private IEnumerator WriteStaff(CreditsItem[] items)
        {
            for (int item = 0; item < items.Length; item++)
            {
                if (items[item].category) WriteCategory(items[item]);
                if (items[item].space) WriteSpacing(items[item]);
                if (items[item].image) WriteImage(items[item]);
                yield return null;
            }
        }

        private void WriteCategory(CreditsItem category)
        {
            ItemLabel label = Instantiate(itemCategory, transform).GetComponent<ItemLabel>();
            label.SetText(category.text);

            for (int a = 0; a < category.actors.Length; a++)
                WriteActor(category.actors[a]);
        }

        private void WriteActor(string actor)
        {
            ItemLabel label = Instantiate(itemActor, transform).GetComponent<ItemLabel>();
            label.SetText(actor);
        }

        private void WriteSpacing(CreditsItem spacing)
        {
            ItemSpacing space = Instantiate(itemSpacing, transform).GetComponent<ItemSpacing>();
            space.AutoConfigure(spacing);
        }

        private void WriteImage(CreditsItem image)
        {
            ItemImage item = Instantiate(itemImage, transform).GetComponent<ItemImage>();
            item.SetImage(image.path);
            item.SetHeight(image.height);
        }
    }
}
