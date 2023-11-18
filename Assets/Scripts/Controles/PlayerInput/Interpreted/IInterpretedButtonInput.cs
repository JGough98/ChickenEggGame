namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public interface IInterpretedButtonInput
    {
        public IConfirmTap Jump
        {
            get;
        }
        public IConfirmTap LayEgg
        {
            get;
        }

        public bool IsGliding
        {
            get;
        }
        public bool IsRunning
        {
            get;
        }
    }
}