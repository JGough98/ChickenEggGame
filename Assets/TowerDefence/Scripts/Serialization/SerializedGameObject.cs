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
		private GameObject instanciatedObject;


		private GameObject InstanciatedObject
		{
			get
			{
				if(instanciatedObject == null)
				{
					instanciatedObject = GameObject.Instantiate(
						serializedObject,
						PrefabCopies.Transform);
					instanciatedObject.gameObject.SetActive(false);
				}

				return instanciatedObject;
			}
		}
	}
}