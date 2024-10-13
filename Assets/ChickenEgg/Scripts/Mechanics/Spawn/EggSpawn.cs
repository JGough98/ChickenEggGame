using CG.ScriptableObjects.Scripts;
using System.Collections.Generic;
using UnityEngine;


namespace CG.Scripts.Mechanics.Spawn
{
    public class EggSpawn : MonoBehaviour, ISpawnPostionAttempt
    {
        [SerializeField]
        private EggConfiguration eggConfiguration;

        [SerializeField]
        private Transform eggSpawnPostion;


        private List<Transform> eggs = new List<Transform>();


        public bool CanFetchPostion => eggs.Count > 0;

        public Vector3 SpawnPostion => PopNextEgg();

        public bool CanLayEgg => eggs.Count < eggConfiguration.EggCount;


        public void TryAddEgg()
        {
            if (CanLayEgg)
            {
                var nextEgg = Instantiate(
                    eggConfiguration.EggPrefab,
                    eggSpawnPostion.transform.position,
                    Quaternion.identity);

                eggs.Add(nextEgg.transform);
            }
        }


        private Vector3 PopNextEgg()
        {
            var egg = eggs[0].transform.position;
            eggs.RemoveAt(0);
            return egg;
        }
    }
}