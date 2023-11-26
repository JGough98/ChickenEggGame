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

        private IConfirmTap jump;
        private IConfirmTap layEgg;

        public bool Jump => jump.Tapped;
        public bool LayEgg => layEgg.Tapped;
        public bool IsGliding => rawPlayerInput.IsGliding.Value;
        public bool IsRunning => rawPlayerInput.IsRunning.Value;


        public InterpretedPlayerInput(IRawPlayerInput rawPlayerInput)
        {
            this.rawPlayerInput = rawPlayerInput;

            jump = new QuedConfirmedTap(rawPlayerInput.Jump);
            layEgg = new QuedConfirmedTap(rawPlayerInput.LayEgg);
        }


        public Vector3 MovementDirection(Vector3 camraForward, Vector3 cameraRight)
            => ((rawPlayerInput.Horizontal.Value * cameraRight) + (rawPlayerInput.Vertical.Value * camraForward));

        public void Update()
        {
            jump.Update();
            layEgg.Update();
        }
    }
}