using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public delegate void MouseFinishedDrag();

	public delegate void MouseStartedDrag();


	public class MouseDrag
	{
		public event MouseStartedDrag OnMouseStartedDrag;

		public event MouseFinishedDrag OnMouseFinishedDrag;


		private readonly Vector3 DEFAULT_DIRECTION = Vector3.forward;

		private List<Vector3> mouseGridDragPositions = new List<Vector3>();
		private List<Vector3> mouseGridDragDirections = new List<Vector3>();
		
		private bool mouseInDrag;


		public bool MouseInDrag => mouseInDrag;

		public IReadOnlyList<Vector3> MouseGridDragPositions => mouseGridDragPositions;
		public IReadOnlyList<Vector3> MouseGridDragDirections => mouseGridDragDirections;


		public IEnumerable<(Vector3 position, Vector3 direction)> PositionToDirection
		{
			get
			{
				var allMouseGridDragPositions = MouseGridDragPositions;
				var allMouseGridDragDirections = MouseGridDragDirections;

				var minLength = Mathf.Min(
					allMouseGridDragPositions.Count,
					allMouseGridDragDirections.Count);

				for(var i = 0; i < minLength; i++)
				{
					yield return (
						allMouseGridDragPositions[i],
						allMouseGridDragDirections[i]);
				}
			}
		}


		public void UpdateDrag(
			Vector3 mouseGridPosition,
			bool nextMouseInDrag)
		{
			HandleDragSwitchedStates(nextMouseInDrag);

			mouseInDrag = nextMouseInDrag;

			UpdateDraggedDirection(mouseGridPosition);
		}


		private void HandleDragSwitchedStates(
			bool nextMouseInDrag)
		{
			if (mouseInDrag == nextMouseInDrag)
				return;

			if (!mouseInDrag && nextMouseInDrag)
			{
				OnMouseStartedDrag?.Invoke();
				return;
			}

			OnMouseFinishedDrag?.Invoke();
			mouseGridDragPositions.Clear();
			mouseGridDragDirections.Clear();
		}

		private void UpdateDraggedDirection(
			Vector3 mouseGridPosition)
		{
			var mouseGridDragPositionsLength = mouseGridDragPositions.Count;

			// If were not in drag or not changed position.
			if (!mouseInDrag ||
				mouseGridDragPositionsLength >= 1
				&& mouseGridDragPositions[mouseGridDragPositionsLength - 1] == mouseGridPosition)
				return;

			// If we've doubled back on ourselves remove prior.
			if (mouseGridDragPositions.Contains(mouseGridPosition))
			{
				RemoveGridPostion(mouseGridPosition);
				return;
			}

			mouseGridDragPositions.Add(mouseGridPosition);

			UpdateDragDirection(mouseGridDragPositionsLength+1);
		}

		private void UpdateDragDirection(int mouseGridDragPositionsLength)
		{
			// Unable to determine direction, set too default.
			if (mouseGridDragPositionsLength == 1)
			{
				mouseGridDragDirections.Add(DEFAULT_DIRECTION);
				return;
			}

			var changeInDirection = GetLatestChangeInDirection(
				mouseGridDragPositionsLength);

			var previouseDirectionIndex = mouseGridDragDirections.Count - 1;

			// If we've changed direction make sure the previous one follows the next direction.
			if (mouseGridDragDirections[previouseDirectionIndex] != changeInDirection)
				mouseGridDragDirections[previouseDirectionIndex] = changeInDirection;
			
			mouseGridDragDirections.Add(changeInDirection);
		}

		private Vector3 GetLatestChangeInDirection(
			int mouseGridDragPositionsCount)
		{
			var endingIndex = mouseGridDragPositionsCount - 1;
			return (mouseGridDragPositions[endingIndex] - mouseGridDragPositions[endingIndex - 1]).normalized;
		}

		private void RemoveGridPostion(
			Vector3 mouseGridPosition)
		{
			var previouseGridPosition = mouseGridDragPositions.IndexOf(mouseGridPosition) + 1;
			var lengthOfRemovedPositions = mouseGridDragPositions.Count - previouseGridPosition;

			RemoveGridRange(previouseGridPosition, lengthOfRemovedPositions);
		}

		private void RemoveGridRange(int startingIndex, int length)
		{
			mouseGridDragPositions.RemoveRange(
				startingIndex,
				length);

			mouseGridDragDirections.RemoveRange(
				startingIndex,
				length);
		}
	}
}