using UnityEngine;


namespace CG.Scripts.Controles.InputReader
{
    public class ButtonRead : IInputReader<bool>
    {
        private string inputName;


        public bool Value => Input.GetButton(inputName);


        public ButtonRead(string inputName)
        {
            this.inputName = inputName;
        }
    }
}
