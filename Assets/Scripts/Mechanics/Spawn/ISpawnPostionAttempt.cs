using UnityEngine;


namespace CG.Scripts.Mechanics.Spawn
{
    public interface ISpawnPostionAttempt
    {
        bool CanFetchPostion
        {
            get;
        }

        public Vector3 SpawnPostion
        {
            get;
        }
    }
}