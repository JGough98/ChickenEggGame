using UnityEngine;


namespace CG.Scripts.Collision.Reaction.Reactions
{
    public class KillPlayer : MonoBehaviour, ICollisionReaction
    {
        public void React(Collider other)
        {
            if (other.name == "Die")
            {
            }
        }
    }
}
