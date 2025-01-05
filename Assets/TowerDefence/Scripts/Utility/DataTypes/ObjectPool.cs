using System.Collections.Generic;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	/// <summary>
	/// Used to manage objects using a object pool design pattern.
	/// </summary>
	/// <typeparam name="T">Type the object pool handles.</typeparam>
	/// <typeparam name="U">Type used to initialize object pool.</typeparam>
	/// <typeparam name="V">Type used to create a new object.</typeparam>
	public class ObjectPool<T, U, V>
	{
		private IObjectPoolQuery<T, U, V> objectPoolQuery;

		private int itemsInUse;

		private List<T> itemPool;


		public T this[int index] => itemPool[index];

		public int Count => itemsInUse;

		public IEnumerable<T> Items
		{
			get
			{
				for (var i = 0; i < itemsInUse; i++)
				{
					yield return itemPool[i];
				}
			}
		}


		public ObjectPool(IObjectPoolQuery<T, U, V> objectPoolFunction)
		{
			this.objectPoolQuery = objectPoolFunction;
			itemPool = new List<T>();
		}


		public T AddItem(V itemInitializeData)
		{
			itemsInUse++;
			if (itemPool.Count < itemsInUse)
			{
				var nextItem = objectPoolQuery.Add(itemInitializeData);
				itemPool.Add(nextItem);
				return nextItem;
			}

			return itemPool[itemsInUse - 1];
		}

		public void RemoveAll()
			=> RemoveItems(0, Count);

		public bool RemoveItems(int startIndex)
			=> RemoveItems(startIndex, Count);

		public bool RemoveItems(int startIndex, int length)
		{
			var removedItems = new List<T>();
			var longerThanPool = GetMinLength(startIndex, length, out var minlength);

			if (!longerThanPool)
			{
				for (var i = startIndex; i < minlength; i++)
				{
					removedItems.Add(itemPool[i]);
				}

				objectPoolQuery.Remove(removedItems);
				itemsInUse -= minlength;
			}

			return !longerThanPool;
		}

		public void Reset()
		{
			objectPoolQuery.Reset(itemPool);
			itemsInUse = 0;
		}


		private bool GetMinLength(
			int startIndex,
			int length,
			out int minLength)
		{
			var actualLength = length - startIndex;
			var lengthIsLongerThanArray = actualLength < 0;

			minLength = lengthIsLongerThanArray
				? 0
				: length;

			return lengthIsLongerThanArray;
		}
	}
}