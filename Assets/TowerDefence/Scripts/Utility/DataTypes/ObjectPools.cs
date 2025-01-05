using System.Collections.Generic;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	/// <summary>
	/// Used to manage several sets of object pools of the same type.
	/// </summary>
	/// <typeparam name="T">Type the object pool handles.</typeparam>
	/// <typeparam name="U">Type used to initialize object pool.</typeparam>
	/// <typeparam name="V">Type used to create a new object.</typeparam>
	public class ObjectPools<T, U, V>
	{
		private IObjectPoolQuery<T, U, V> objectPoolQuery;

		private Dictionary<U, ObjectPool<T, U, V>> objectPools;

		private U currentPoolType;

		// Surely we can add null-able type to above to remove need of this?
		private bool initialized;


		public ObjectPool<T, U, V> Pool => !initialized
			? default
			: objectPools[currentPoolType];


		public ObjectPools(IObjectPoolQuery<T, U, V> objectPoolQuery)
		{
			this.objectPoolQuery = objectPoolQuery;
			objectPools = new Dictionary<U, ObjectPool<T, U, V>>();
		}


		public void TryAddNewPool(U poolInitializeData)
		{
			var currentPool = Pool;
			if (currentPool != null)
				currentPool.Reset();

			if (!objectPools.ContainsKey(poolInitializeData))
			{
				var objectPool = new ObjectPool<T, U, V>(objectPoolQuery);
				objectPools.Add(poolInitializeData, objectPool);
			}

			objectPoolQuery.Initialize(poolInitializeData);
			currentPoolType = poolInitializeData;
			initialized = true;
		}
	}
}