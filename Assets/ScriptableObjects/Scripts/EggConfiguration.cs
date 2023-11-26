using UnityEngine;


namespace CG.ScriptableObjects.Scripts
{
    [CreateAssetMenu(menuName = "Assets/EggConfiguration")]
    public class EggConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject eggPrefab;

        [SerializeField]
        private int eggCount;


        public GameObject EggPrefab => eggPrefab;

        public int EggCount => eggCount;
    }
}
