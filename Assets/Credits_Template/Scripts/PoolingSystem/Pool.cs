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

        private Stack<ItemActor> freeActor = new Stack<ItemActor>();
        private Stack<ItemCategory> freeCategory = new Stack<ItemCategory>();

        public ItemActor GetActor(Transform newParent)
        {
            if (freeActor.Count <= 0) AddActor();

            ItemActor actor = freeActor.Pop();
            actor.transform.SetParent(newParent);
            return actor;
        }

        public void ReleaseActor(ItemActor actor)
        {
            onRemovedItem?.Invoke(actor.GetHeight());
            actor.transform.SetParent(transform);
            freeActor.Push(actor);
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

        public void ReleaseCategory(ItemCategory category)
        {
            onRemovedItem?.Invoke(category.GetHeight());
            category.transform.SetParent(transform);
            freeCategory.Push(category);
        }

        private void AddCategory()
        {
            ItemCategory label = Instantiate(categoryPrefab, transform).GetComponent<ItemCategory>();
            label.SetPool(this);
            freeCategory.Push(label);
        }
    }
}
