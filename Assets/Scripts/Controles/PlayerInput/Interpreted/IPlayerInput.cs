namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public interface IPlayerInput : IInterpretedButtonInput, IInturprettedPlayerMovementDirection
    {
        public void Update();
    }
}
