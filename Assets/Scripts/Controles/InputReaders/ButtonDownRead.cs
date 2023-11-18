using UnityEngine;


namespace CG.Scripts.Controles.InputReader
{
    public class ButtonDownRead : IInputReader<bool>
    {
        private string inputName;


        public bool Value => Input.GetButtonDown(inputName);


        public ButtonDownRead(string inputName)
        {
            this.inputName = inputName;
        }
    }
}
