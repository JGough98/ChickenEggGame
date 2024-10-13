using System.Collections.Generic;
using UnityEngine;


namespace CG.Scripts.Mechanics.Spawn
{
    public class SpawnPostionManager : MonoBehaviour, ISpawn
    {
        [SerializeField]
        private EggSpawn eggSpawn;


        private IReadOnlyList<ISpawnPostionAttempt> spwanPostionAttmpts;


        public Vector3 Posistion
        {
            get
            {
                foreach (var spwanPostionAttmpt in spwanPostionAttmpts)
                {
                    if (spwanPostionAttmpt.CanFetchPostion)
                    {
                        return spwanPostionAttmpt.SpawnPostion;
                    }
                }

                return default;
            }
        }


        public void Awake()
        {
            spwanPostionAttmpts = new List<ISpawnPostionAttempt>()
            {
                new DefaultSpawn(transform.position),
                eggSpawn
            };
        }
    }
}