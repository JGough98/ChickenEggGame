using System;


namespace Assets.TowerDefense.Scripts.Enums
{
	[Flags]
	public enum ERecourseType
	{
		IRON = 1 << 0,
		SULFUR = 1 << 1,
	}
}