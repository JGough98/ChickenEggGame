using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Utility
{
	public static class Guard
	{
		public static bool GuardAgainstNull<T>(
			this IEnumerable<T> items)
			=> IsNotNull(items)
				&& ContainNoNullElements(items)
				&& ContainsElements(items);


		private static bool IsNotNull<T>(
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
				Debug.LogError($"{GuardMessageStart<T>()} Enumrable has no elements.");

			return !containsNoElements;
		}

		private static bool ContainNoNullElements<T>(
			this IEnumerable<T> items)
		{
			var containsNullElements = items.Any(x => x == null);

			if (containsNullElements)
				Debug.LogError($"{GuardMessageStart<T>()} Enumrable contains null elements.");

			return !containsNullElements;
		}

		private static string GuardMessageStart<T>()
			=> $"Guard ({typeof(T).Name}) -";
	}
}