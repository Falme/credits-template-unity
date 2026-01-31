using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace FalmeStreamless.Credits
{
    public class Staff : MonoBehaviour
    {
        [Header("Prefab Items")]
        [SerializeField] private GameObject itemTitle;

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
            for (int item = 0; item < items.Length; item++)
            {
				int indexCopy = item;
                if (items[item].title)  orderItems.Enqueue(() => WriteTitle(items[indexCopy].text));
				else if (items[item].space)  orderItems.Enqueue(() => WriteSpacing(items[indexCopy].height));
                else if (items[item].image)  orderItems.Enqueue(() => WriteImage(items[indexCopy]));
				else if (items[item].category) 
				{
					orderItems.Enqueue(() => WriteCategory(items[indexCopy]));

					if (items[item].categorySpacing > 0f)
						orderItems.Enqueue(() => WriteSpacing(items[indexCopy].categorySpacing));

					for (int a = 0; a < items[item].actors.Length; a++)
					{
						int actorIndex = a;
						orderItems.Enqueue(() => WriteActor(items[indexCopy].actors[actorIndex]));

						if (items[item].actorsSpacing > 0f)
							orderItems.Enqueue(() => WriteSpacing(items[indexCopy].actorsSpacing));
					}
				}

				if(item == 0) 
					DequeueItem();
                yield return null;
            }
        }

		public void DequeueItem()
		{
			if(orderItems.Count > 0)
				orderItems.Dequeue().Invoke();
		}

        private void WriteTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return;

            ItemTitle label = pool.title.GetItem(transform);
            label.SetText(title);
        }

        private void WriteCategory(CreditsItemData category)
        {
            ItemCategory label = pool.category.GetItem(transform);
            label.onDrawSpace += EnqueueSpacing;
            label.onDrawActor += EnqueueActor;

            label.Initialize(category);

            label.onDrawSpace -= EnqueueSpacing;
            label.onDrawActor -= EnqueueActor;
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

            ItemActor label = pool.actor.GetItem(transform);
            label.SetText(actor);
        }

        private void WriteSpacing(float height)
        {
            if (height <= 0) return;

            ItemSpacing space = pool.spacing.GetItem(transform);
            space.SetHeight(height);
        }

        private void WriteImage(CreditsItemData image)
        {
            ItemImage item = pool.image.GetItem(transform);
            item.Initialize(image);
        }
    }
}
