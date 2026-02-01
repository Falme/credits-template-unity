using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FalmeStreamless.Credits
{
    public class Staff : MonoBehaviour
    {
        [Header("Pooling System")]
        [SerializeField] private Pool pool;

		private Queue<Action> orderItems = new Queue<Action>();

        public void Initialize(CreditsData data)
        {
            Clear();
            StartCoroutine(WriteStaff(data.items));
        }

		private void Update()
		{
			if(transform.childCount <= 0) return;

			CreditsItem item = transform.GetChild(transform.childCount-1).GetComponent<CreditsItem>();
			if(item != null && item.hasPassedBottomBorder())
				DequeueItem();
		}

        private void Clear()
        {
            while (transform.childCount > 0)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }

        private IEnumerator WriteStaff(CreditsItemData[] items)
        {
            for (int a = 0; a < items.Length; a++)
            {
				int item = a;
				string id = items[item].type.ToLower();

				switch(id)
				{
					case "category":
						orderItems.Enqueue(() => WriteCategory(items[item]));

						for (int b = 0; b < items[item].actors.Length; b++)
						{
							int actor = b;
							orderItems.Enqueue(() => WriteActor(items[item].actors[actor]));
						}
						break;
					default:
						orderItems.Enqueue(() => WriteItem(id, items[item]));
						break;
				}

				if(item == 0) 
					DequeueItem();
                yield return null;
            }
        }

		public void DequeueItem()
		{
			if(orderItems.Any())
				orderItems.Dequeue().Invoke();
		}

        private void WriteCategory(CreditsItemData category)
        {
            ItemCategory label = (ItemCategory)pool.GetItem("category", transform);

            label.Initialize(category);
        }

		public void EnqueueActor(string actor)
		{
			orderItems.Enqueue(() => WriteActor(actor));
		}

        private void WriteActor(string actor)
        {
            if (string.IsNullOrEmpty(actor)) return;

            ItemActor label = (ItemActor)pool.GetItem("actor", transform);
            label.SetText(actor);
        }

		private void WriteItem(string id, CreditsItemData data)
		{
            CreditsItem item = pool.GetItem(id, transform);
            item.Initialize(data);
		}
    }
}
