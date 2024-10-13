using System;
using UnityEngine;


namespace CG.ScriptableObjects.Scripts
{
    [CreateAssetMenu(menuName = "Assets/JumpConfiguration")]
    public class JumpConfiguration : ScriptableObject
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float [] jumpPercentage;

        public float this[int index]
        {
            get
            {
                index = Mathf.Clamp(index, 0, JumpCount-1);
                return jumpPercentage[index];
            }
        }

        public int JumpCount => jumpPercentage.Length;
    }
}