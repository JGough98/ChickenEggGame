using CG.Scripts.Controles.InputReader;


namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public class ConfirmTap : IConfirmTap
    {
        private IInputReader<bool> tapReader;

        private bool tapped;

        public bool Tapped
        {
            get
            {
                if(!tapped)
                {
                    return false;
                }
                tapped = false;
                return true;
            }
        }


        public ConfirmTap(IInputReader<bool> tapReader)
        {
            this.tapReader = tapReader;
        }


        public void Update()
        {
            if(tapReader.Value)
            {
                tapped = true;
            }
        }
    }
}