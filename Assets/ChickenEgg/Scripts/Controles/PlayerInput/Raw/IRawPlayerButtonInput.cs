using CG.Scripts.Controles.InputReader;

namespace CG.Scripts.Controles.PlayerInput
{
    public interface IRawPlayerButtonInput
    {
        public IInputReader<bool> Jump
        {
            get;
        }
        public IInputReader<bool> IsGliding
        {
            get;
        }
        public IInputReader<bool> IsRunning
        {
            get;
        }
        public IInputReader<bool> LayEgg
        {
            get;
        }
    }
}
