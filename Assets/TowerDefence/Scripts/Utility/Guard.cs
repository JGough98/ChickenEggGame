using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility
{
	public static class Guard
	{
		public static bool GuardEnumrableAgainstNull<T>(
			this IEnumerable<T> items)
			=> GuardAgainstNull(items)
				&& ContainNoNullElements(items)
				&& ContainsElements(items);


		public static bool GuardAgainstNull<T>(
			this T item)
		{
			var isNull = item == null;

			if (isNull)
				Debug.LogError($"{GuardMessageStart<T>()} Type is undefined.");

			return !isNull;
		}

		private static bool ContainsElements<T>(
			this IEnumerable<T> items)
		{
			var containsNoElements = items.Count() == 0;

			if (containsNoElements)
				Debug.LogError($"{GuardMessageStart<T>()} Enumerable has no elements.");

			return !containsNoElements;
		}

		private static bool ContainNoNullElements<T>(
			this IEnumerable<T> items)
		{
			var containsNullElements = items.Any(x => x == null);

			if (containsNullElements)
				Debug.LogError($"{GuardMessageStart<T>()} Enumerable contains null elements.");

			return !containsNullElements;
		}

		private static string GuardMessageStart<T>()
			=> $"Guard ({typeof(T).Name}) -";
	}
}