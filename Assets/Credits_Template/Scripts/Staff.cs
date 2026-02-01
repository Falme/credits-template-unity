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
				switch(items[item].type.ToLower())
				{
					case "title":
						orderItems.Enqueue(() => WriteTitle(items[item].text));
						break;
					case "space":
						EnqueueSpacing(items[item].height);
						break;
					case "image":
						orderItems.Enqueue(() => WriteImage(items[item]));
						break;
					case "category":
						orderItems.Enqueue(() => WriteCategory(items[item]));

						if (items[item].categorySpacing > 0f)
							EnqueueSpacing(items[item].categorySpacing);

						for (int b = 0; b < items[item].actors.Length; b++)
						{
							int actor = b;
							orderItems.Enqueue(() => WriteActor(items[item].actors[actor]));

							if (items[item].actorsSpacing > 0f)
								EnqueueSpacing(items[item].actorsSpacing);
						}
						break;
					default:
						Debug.LogError("You mispelled some type in credits JSON!");
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

        private void WriteTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return;

            ItemTitle label = (ItemTitle)pool.GetItem("title", transform);
            label.SetText(title);
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

		public void EnqueueSpacing(float height)
		{
			orderItems.Enqueue(() => WriteSpacing(height));
		}

        private void WriteActor(string actor)
        {
            if (string.IsNullOrEmpty(actor)) return;

            ItemActor label = (ItemActor)pool.GetItem("actor", transform);
            label.SetText(actor);
        }

        private void WriteSpacing(float height)
        {
            if (height <= 0) return;

            ItemSpacing space = (ItemSpacing)pool.GetItem("space", transform);
            space.SetHeight(height);
        }

        private void WriteImage(CreditsItemData image)
        {
            ItemImage item = (ItemImage)pool.GetItem("image", transform);
            item.Initialize(image);
        }
    }
}
