using System;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Serialization
{
	/// <summary>
	/// This class is used to fix an issue where edits made to a prefab persist.
	/// </summary>
	[Serializable]
	public class SerializedGameObject
	{
		public static implicit operator GameObject(SerializedGameObject gameObject)
			=> gameObject.InstanciatedObject;


		[SerializeField]
		private GameObject serializedObject;
		private GameObject instanciatedSerilizedObject;


		private GameObject InstanciatedObject
		{
			get
			{
				if(instanciatedSerilizedObject == null)
				{
					instanciatedSerilizedObject = GameObject.Instantiate(
						serializedObject,
						PrefabCopies.Transform);
					instanciatedSerilizedObject.gameObject.SetActive(false);
				}

				return instanciatedSerilizedObject;
			}
		}
	}
}