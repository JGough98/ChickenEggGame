using UnityEngine;


namespace CG.Scripts.Controles.InputReader
{
    public class ButtonUpRead : IInputReader<bool>
    {
        private string inputName;


        public bool Value => Input.GetButtonUp(inputName);


        public ButtonUpRead(string inputName)
        {
            this.inputName = inputName;
        }
    }
}