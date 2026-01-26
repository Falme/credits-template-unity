using UnityEngine;
using System.Collections.Generic;
using System;

namespace FalmeStreamless.Credits
{
    public class Pool : MonoBehaviour
    {
        public static event Action<float> onRemovedItem;

        [SerializeField] private ItemActor actorPrefab;

        private Stack<ItemActor> freeActor = new Stack<ItemActor>();

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

    }
}
