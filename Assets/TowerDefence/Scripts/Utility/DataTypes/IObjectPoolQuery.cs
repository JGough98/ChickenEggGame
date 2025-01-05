using System.Collections.Generic;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	/// <summary>
	/// Used as the set of quires to handle write operations on the object pool.
	/// </summary>
	/// <typeparam name="T">Type the object pool handles.</typeparam>
	/// <typeparam name="U">Type used to create a new object.</typeparam>
	/// <typeparam name="V">Type used to initialize object pool.</typeparam>
	public interface IObjectPoolQuery<T, U, V>
	{
		void Initialize(U intializeData);

		T Add(V itemInitializeData);

		void Remove(IEnumerable<T> removedItems);

		void Reset(IEnumerable<T> resetItems);
	}
}