using UnityEngine;


namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    /// <summary>
    ///  Used to inturpret the player input into a more usable form.
    ///  This should include hard defined rules about how we inturpret the player input.
    /// </summary>
    public class InterpretedPlayerInput : IPlayerInput
    {
        private IRawPlayerInput rawPlayerInput;


        public bool Jump => rawPlayerInput.Jump;
        public bool IsGliding => rawPlayerInput.IsGliding;
        public bool IsRunning => rawPlayerInput.IsRunning;
        public bool LayEgg => rawPlayerInput.LayEgg;


        public InterpretedPlayerInput(IRawPlayerInput rawPlayerInput)
        {
            this.rawPlayerInput = rawPlayerInput;
        }


        public Vector3 MovementDirection(Vector3 camraForward, Vector3 cameraRight)
            => ((rawPlayerInput.Horizontal * cameraRight) + (rawPlayerInput.Vertical * camraForward));
    }
}