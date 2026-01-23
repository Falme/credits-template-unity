using UnityEngine;
using System.Collections.Generic;

namespace FalmeStreamless.Credits
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private int initialBatch;

        [SerializeField] private ItemActor actorPrefab;

        private Stack<ItemActor> freeActor = new Stack<ItemActor>();
        private Stack<ItemActor> busyActor = new Stack<ItemActor>();

        private void Start()
        {
            for (int a = 0; a < initialBatch; a++)
            {
                Debug.Log("Created Category");
                // Debug.Log("Created Actor");
                AddActor();
                Debug.Log("Created Image");
                Debug.Log("Created Space");
            }
        }

        public ItemActor GetActor(Transform newParent)
        {
            if (freeActor.Count <= 0) AddActor();

            ItemActor actor = freeActor.Pop();
            busyActor.Push(actor);
            actor.transform.SetParent(newParent);
            return actor;
        }

        public void ReleaseActor()
        {

        }

        private void AddActor()
        {
            ItemActor label = Instantiate(actorPrefab, transform).GetComponent<ItemActor>();
            freeActor.Push(label);
        }

    }
}
