namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public interface IInterpretedButtonInput
    {
        public bool Jump
        {
            get;
        }
        public bool LayEgg
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