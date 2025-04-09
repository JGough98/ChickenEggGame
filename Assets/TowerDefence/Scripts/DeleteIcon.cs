using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using TriggerEnterExit;


	public class DeleteIcon : TriggerEnterExit<GameObject>
	{
		[SerializeField]
		private MeshRenderer meshRenderer;

		[SerializeField]
		private string deleteTagName;

		[SerializeField]
		private Material canDeleteMaterial;

		[SerializeField]
		private Material cantDeleteMaterial;

		private List<GameObject> obejctsToDelete;

		private bool isInDelete;


		public void Delete()
		{
			foreach (var objectToDelete in obejctsToDelete)
			{
				var toDelete = objectToDelete.GetComponent<IDestroyedEvent>();

				if (toDelete == null)
				{
					throw new System.Exception("Found deletable objects without the IDestroyedEvent handler.");
				}
				else
				{
					toDelete.SafeDestroy(objectToDelete);
				}
			}
		}


		protected override void FoundTarget(GameObject target)
		{
			if (target.tag == deleteTagName)
			{
				obejctsToDelete.Add(target);
				TrySetMaterial();
			}
		}

		protected override void LostTarget(GameObject target)
		{
			if (obejctsToDelete.Remove(target))
			{
				TrySetMaterial();
			}
		}


		private void TrySetMaterial()
		{
			var deletionInSight = obejctsToDelete.Any();

			if (isInDelete != deletionInSight)
			{
				isInDelete = deletionInSight;

				meshRenderer.materials = deletionInSight
					? new Material[] { canDeleteMaterial }
					: new Material[] { cantDeleteMaterial };
			}
		}

		private void Reset()
		{
			meshRenderer = gameObject.GetComponent<MeshRenderer>();
		}
	}
}