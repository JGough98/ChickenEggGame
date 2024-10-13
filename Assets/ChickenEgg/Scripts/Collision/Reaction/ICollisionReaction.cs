using UnityEngine;


namespace CG.Scripts.Collision.Reaction
{
    public interface ICollisionReaction
    {
        void React(Collider other);
    }
}