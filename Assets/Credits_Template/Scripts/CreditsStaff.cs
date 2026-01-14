using UnityEngine;
using System.Collections;

namespace FalmeStreamless.Credits
{
    public class CreditsStaff : MonoBehaviour
    {
        [Header("Prefab Items")]
        [SerializeField] private GameObject itemTitle;
        [SerializeField] private GameObject itemCategory;
        [SerializeField] private GameObject itemActor;

        public void Initialize(CreditsData data)
        {
            ClearStaff();
            WriteTitle(data.title);
            StartCoroutine(WriteStaff(data.labels));
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

        private IEnumerator WriteStaff(string[,] labels)
        {
            for (int category = 0; category < labels.GetLength(0); category++)
            {
                WriteCategory(labels[category, 0]);
                yield return null;

                for (int label = 1; label < labels.GetLength(1); label++)
                {
                    WriteActor(labels[category, label]);
                    yield return null;
                }
            }
        }

        private void WriteCategory(string category)
        {
            ItemLabel label = Instantiate(itemCategory, transform).GetComponent<ItemLabel>();
            label.SetText(category);
        }

        private void WriteActor(string actor)
        {
            ItemLabel label = Instantiate(itemActor, transform).GetComponent<ItemLabel>();
            label.SetText(actor);
        }
    }
}
