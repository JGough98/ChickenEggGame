using UnityEngine;


namespace CG.Scripts.Controles.PlayerInput
{
    public interface IInturprettedPlayerMovementDirection
    {
        public Vector3 MovementDirection(
            Vector3 camraForward,
            Vector3 cameraRight);
    }
}
