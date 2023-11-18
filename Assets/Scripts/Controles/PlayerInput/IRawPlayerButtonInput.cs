namespace CG.Scripts.Controles.PlayerInput
{
    public interface IRawPlayerButtonInput
    {
        public bool Jump
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
        public bool LayEgg
        {
            get;
        }
    }
}
