using System;


namespace Assets.TowerDefence.Scripts.Enums
{
	[Flags]
	public enum ERecourseType
	{
		IRON = 1 << 0,
		SULFUR = 1 << 1,
	}
}