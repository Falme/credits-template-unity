using UnityEngine;
using System.Collections.Generic;

namespace FalmeStreamless.Credits
{
    [System.Serializable]
    public class PoolItem<T> where T : CreditsItem
    {
		[SerializeField] private T itemPrefab;

		private Pool pool;
        private Stack<T> freeItems = new Stack<T>();

		public void Initialize(Pool pool)
		{
			this.pool = pool;
		}

        public T GetItem(Transform newParent)
        {
            if (freeItems.Count <= 0) Add();
			
            T item = freeItems.Pop();
            item.transform.SetParent(newParent);
            return item;
        }
		
        private void Add()
        {
            T item = MonoBehaviour.Instantiate(itemPrefab, pool.transform).GetComponent<T>();
            item.SetPool(pool);
            freeItems.Push(item);
        }

		public void FreeItem(T item)
		{
			freeItems.Push(item);
		}

    }
}
