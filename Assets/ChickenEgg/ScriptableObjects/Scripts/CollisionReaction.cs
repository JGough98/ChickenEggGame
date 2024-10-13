using CG.Scripts.Collision.Reaction;
using UnityEngine;


namespace Assets.ScriptableObjects.Scripts
{
    // Ok so my though is that we could have scriptable obejcts in which serialise a singular interface type.
    // Then we will create a dropdown menu where we will do a find all classes implmenting x as the dropdown names.
    // From here the user can serilise the interface to the SO and here we can drop these SO's to are hearts content.
    // Will need reflection utility to serilise these values.
    // Will need simple dropdown UI to show all avaliable values.
    // Then we will also need to inject these values within the intialiser.
    // Need Zenejct.
    [CreateAssetMenu(menuName = "Assets/Something")]
    public class CollisionReaction : ScriptableObject
    {
        /*[SerializeReference]
        private ICollisionReaction collsion;*/
    }
}
