using UnityEngine;


public interface ISpawnAnimation
{
    public delegate void DisableControle();

    public event DisableControle DisableMovement
    {
        add
        { }
        remove
        { }
    }


    public void PlayAnimation();
}


public interface ITeleportPlayer
{
    bool TeleportPlayer(Vector3 playerPostion);
}


// The egg will be used to telport to the player to there previouse postion.
// When the egg is on the ground a loner animation will play with a brief period where the player waits.
public class Egg : MonoBehaviour, ITeleportPlayer
{
    private bool isAlive = false;

    // TODO - We will need to take into account that the eggs postion may out of bounds of the map.
    private Vector3 CurrentPostion => gameObject.transform.position;

    // Woweee!
    public bool TeleportPlayer(Vector3 playerPostion)
    {
        throw new System.NotImplementedException();
    }


    private void Start()
    {

    }
}
