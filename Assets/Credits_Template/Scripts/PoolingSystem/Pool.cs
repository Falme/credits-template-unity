using UnityEngine;
using System;

namespace FalmeStreamless.Credits
{
    public class Pool : MonoBehaviour
    {
        public static event Action<float> onRemovedItem;

		public PoolItem<ItemActor> actor;
		public PoolItem<ItemCategory> category;
		public PoolItem<ItemSpacing> spacing;
		public PoolItem<ItemImage> image;

		void Awake()
		{
			actor.Initialize(this);
			category.Initialize(this);
			spacing.Initialize(this);
			image.Initialize(this);
		}

        public void Release(CreditsItem item)
        {
            onRemovedItem?.Invoke(item.GetHeight());
            item.transform.SetParent(transform);

            if (item is ItemActor) actor.FreeItem((ItemActor)item);
            if (item is ItemCategory) category.FreeItem((ItemCategory)item);
            if (item is ItemSpacing) spacing.FreeItem((ItemSpacing)item);
            if (item is ItemImage) image.FreeItem((ItemImage)item);
        }
    }
}
