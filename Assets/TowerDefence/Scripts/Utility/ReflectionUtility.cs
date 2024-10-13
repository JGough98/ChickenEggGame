using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public static class ReflectionUtility
{
	public static void SerializeAllListsWithValuesFromScene(
		System.Object obj)
	{
		var baseTypeFeildInfos = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

		foreach (var baseFieldInfo in baseTypeFeildInfos)
		{
			if (IsGenericList(baseFieldInfo) && GetListMonoBehaviourGenericType(baseFieldInfo, out var genericType))
			{
				AssignListValues(
					new object[] { UnityEngine.Object.FindObjectsOfType(genericType) },
					genericType,
					baseFieldInfo,
					obj);
			}
		}
	}

	public static bool IsGenericList(FieldInfo fieldInfo)
		=> fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(List<>);

	public static void AssignListValues(
		object[] newValues,
		Type genericType,
		FieldInfo listField,
		System.Object orginalObject)
	{
		var typedList = Activator.CreateInstance(typeof(List<>).MakeGenericType(genericType));
		var addRangeMethod = typedList.GetType().GetMethod("AddRange");
		addRangeMethod.Invoke(typedList, newValues);
		listField.SetValue(orginalObject, typedList);
	}

	public static bool GetListMonoBehaviourGenericType(
		FieldInfo fieldInfo,
		out Type genericType)
	{
		genericType = null;
		var allGenericArguments = fieldInfo.FieldType.GetGenericArguments();

		if (allGenericArguments.Count() > 1)
		{
			Debug.LogError($"Serializer cannot handle multiple generic arguments, violating Field Name : {fieldInfo.FieldType.Name}");

			return false;
		}

		genericType = allGenericArguments[0];
		var isMonoBehaviour = genericType.IsSubclassOf(typeof(MonoBehaviour));

		if (!genericType.IsSubclassOf(typeof(MonoBehaviour)))
		{
			Debug.LogError($"Generic type is not of type {typeof(MonoBehaviour).Name}.");
			return false;
		}

		return isMonoBehaviour;
	}
}

