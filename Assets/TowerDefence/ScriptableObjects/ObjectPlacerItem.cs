// Ignore Spelling: Scriptable
using UnityEngine;


namespace Assets.TowerDefense.ScriptableObjects
{
	using Scripts.Serialization;


	[CreateAssetMenu(fileName = "ObjectPlacerItem-", menuName = "ScriptableObjects/ObjectPlacerItem", order = 6)]
	public class ObjectPlacerItem : ScriptableObject
	{
		[SerializeField]
		private string uiButtonName;

		[SerializeField]
		private bool canDragMultiple;

		[SerializeField]
		private SerializedGameObject shown;
		[SerializeField]
		private SerializedGameObject placed;


		public string UIButtonName => uiButtonName;

		public bool CanDragMultiple => canDragMultiple;
		public bool CanRotate => !canDragMultiple;

		public GameObject Shown => shown;
		public GameObject Placed => placed;
	}
}