namespace CG.Scripts.Controles.PlayerInput
{
    public interface IPlayerInput
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

        public float Up
        {
            get;
        }
        public float Down
        {
            get;
        }
        public float Left
        {
            get;
        }
        public float Right
        {
            get;
        }
    }
}
