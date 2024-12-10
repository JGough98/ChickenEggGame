using UnityEngine;


namespace Assets.TowerDefense.ScriptableObjects
{
	[CreateAssetMenu(fileName = "ObjectPlacerItem-", menuName = "ScriptableObjects/ObjectPlacerItem", order = 6)]
	public class ObjectPlacerItem : ScriptableObject
	{
		[SerializeField]
		private GameObject shown;
		[SerializeField]
		public GameObject placed;


		public GameObject Shown => shown;
		public GameObject Placed => placed;
	}
}