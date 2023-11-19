using System;
using UnityEngine;


namespace CG.Scripts
{
    public class DirectionalRayCollision : MonoBehaviour
    {
        [SerializeField]
        private Transform taregt;

        [SerializeField]
        private TransformDirection transformDirection;

        [SerializeField]
        private int layerMask;

        [SerializeField]
        private float distanceToCollisionTollarance;


        private Func<Vector3> targetCollisionDirection;

        private RaycastHit hit;

        private float rayLength;

        private bool collided;


        public bool Collided => collided;


        public void Awake()
        {
            // Bit shift the index of the layer (8) to get a bit mask
            layerMask = 1 << layerMask;
            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            (rayLength, targetCollisionDirection) = taregt.GetLengthAndDirecton(transformDirection);
            rayLength += distanceToCollisionTollarance;
        }


        public void FixedUpdate()
        {
            CheckCollision();
            DebugRays();
        }


        private void CheckCollision()
        {
            collided = Physics.Raycast(
                taregt.position,
                targetCollisionDirection(),
                // May need to check what the ray hit one day!
                out hit,
                rayLength,
                layerMask);
        }

        private void DebugRays()
        {
            // Does the ray intersect any objects excluding the taregt layer
            if (collided)
            {
                Debug.Log(hit.collider.gameObject.name, hit.collider.gameObject);
                Debug.DrawRay(taregt.position, targetCollisionDirection() * hit.distance, Color.red);
                //Debug.Log("Did Hit");
            }
        }
    }
}
