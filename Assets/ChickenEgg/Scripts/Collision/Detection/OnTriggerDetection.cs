using CG.Scripts.Collision.Reaction;
using System.Collections.Generic;
using UnityEngine;


namespace CG.Scripts.Collision.Detection
{
    public class OnTriggerDetection : MonoBehaviour
    {
        private IList<ICollisionReaction> collisionReaction;


        private void Awake()
        {
            collisionReaction = GetComponents<ICollisionReaction>();

            if (collisionReaction == null)
            {
                Debug.LogError("OnTriggerReaction has no ColisionReaction");
            }
        }


        private void OnTriggerEnter(Collider collision)
        {
            foreach (var collisionReaction in collisionReaction)
            {
                collisionReaction.React(collision);
            }
        }
    }
}