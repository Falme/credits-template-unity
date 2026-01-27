using UnityEngine;
using System.Collections.Generic;
using System;

namespace FalmeStreamless.Credits
{
    public class Pool : MonoBehaviour
    {
        public static event Action<float> onRemovedItem;

        [SerializeField] private ItemActor actorPrefab;
        [SerializeField] private ItemCategory categoryPrefab;
        [SerializeField] private ItemSpacing spacingPrefab;
        [SerializeField] private ItemImage imagePrefab;

        private Stack<ItemActor> freeActor = new Stack<ItemActor>();
        private Stack<ItemCategory> freeCategory = new Stack<ItemCategory>();
        private Stack<ItemSpacing> freeSpacing = new Stack<ItemSpacing>();
        private Stack<ItemImage> freeImage = new Stack<ItemImage>();

        public ItemActor GetActor(Transform newParent)
        {
            if (freeActor.Count <= 0) AddActor();

            ItemActor actor = freeActor.Pop();
            actor.transform.SetParent(newParent);
            return actor;
        }

        private void AddActor()
        {
            ItemActor label = Instantiate(actorPrefab, transform).GetComponent<ItemActor>();
            label.SetPool(this);
            freeActor.Push(label);
        }

        public ItemCategory GetCategory(Transform newParent)
        {
            if (freeCategory.Count <= 0) AddCategory();

            ItemCategory category = freeCategory.Pop();
            category.transform.SetParent(newParent);
            return category;
        }

        private void AddCategory()
        {
            ItemCategory label = Instantiate(categoryPrefab, transform).GetComponent<ItemCategory>();
            label.SetPool(this);
            freeCategory.Push(label);
        }

        public ItemSpacing GetSpacing(Transform newParent)
        {
            if (freeSpacing.Count <= 0) AddSpacing();

            ItemSpacing spacing = freeSpacing.Pop();
            spacing.transform.SetParent(newParent);
            return spacing;
        }

        private void AddSpacing()
        {
            ItemSpacing label = Instantiate(spacingPrefab, transform).GetComponent<ItemSpacing>();
            label.SetPool(this);
            freeSpacing.Push(label);
        }

        public ItemImage GetImage(Transform newParent)
        {
            if (freeImage.Count <= 0) AddImage();

            ItemImage image = freeImage.Pop();
            image.transform.SetParent(newParent);
            return image;
        }

        private void AddImage()
        {
            ItemImage label = Instantiate(imagePrefab, transform).GetComponent<ItemImage>();
            label.SetPool(this);
            freeImage.Push(label);
        }

        public void Release(CreditsItem item)
        {
            onRemovedItem?.Invoke(item.GetHeight());
            item.transform.SetParent(transform);

            if (item is ItemActor)
                freeActor.Push((ItemActor)item);
            if (item is ItemCategory)
                freeCategory.Push((ItemCategory)item);
            if (item is ItemSpacing)
                freeSpacing.Push((ItemSpacing)item);
            if (item is ItemImage)
                freeImage.Push((ItemImage)item);
        }
    }
}
