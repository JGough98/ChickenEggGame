namespace CG.Scripts.Controles.PlayerInput.Interpreted
{
    public interface IConfirmTap
    {
        public bool Tapped
        {
            get;
        }

        public void Update();
    }
}