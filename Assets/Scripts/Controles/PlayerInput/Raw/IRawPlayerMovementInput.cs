using CG.Scripts.Controles.InputReader;


namespace CG.Scripts.Controles.PlayerInput
{
    public interface IRawPlayerMovementInput
    {
        public IInputReader<float> Vertical
        {
            get;
        }
        public IInputReader<float> Horizontal
        {
            get;
        }
    }
}
