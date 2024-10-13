using CG.Scripts.Controles.InputReader;


namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public class QuedConfirmedTap : IConfirmTap
    {
        private IInputReader<bool> tapReader;

        private int tapCount;

        public bool Tapped
        {
            get
            {
                if(tapCount > 0)
                {
                    tapCount--;
                    return true;
                }
                return false;
            }
        }

        public QuedConfirmedTap(IInputReader<bool> tapReader)
        {
            this.tapReader = tapReader;
        }


        public void Update()
        {
            if (tapReader.Value)
            {
                tapCount++;
            }
        }
    }
}