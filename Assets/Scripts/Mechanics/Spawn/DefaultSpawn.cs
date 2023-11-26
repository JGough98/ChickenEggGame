using UnityEngine;


namespace CG.Scripts.Mechanics.Spawn
{
    public interface ISetDefaultSpawnPostion
    {
        void UpdatePostion(Vector3 postion);
    }



    public class DefaultSpawn : ISpawnPostionAttempt, ISetDefaultSpawnPostion
    {
        private Vector3 startingPostion;


        public bool CanFetchPostion => true;

        public Vector3 SpawnPostion => startingPostion;


        public DefaultSpawn(Vector3 startingPostion)
        {
            this.startingPostion = startingPostion;
        }


        public void UpdatePostion(Vector3 postion)
        {
            startingPostion = postion;
        }
    }
}
