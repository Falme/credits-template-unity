using UnityEngine;

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
            WriteStaff(data.labels);
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

        private void WriteStaff(string[,] labels)
        {
            for (int category = 0; category < labels.GetLength(0); category++)
            {
                WriteCategory(labels[category, 0]);

                for (int label = 1; label < labels.GetLength(1); label++)
                    WriteActor(labels[category, label]);
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
