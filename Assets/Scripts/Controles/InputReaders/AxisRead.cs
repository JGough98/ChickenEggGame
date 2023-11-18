using CG.Scripts.Controles.InputReader;
using UnityEngine;


namespace CG.Scripts.Controles
{
    public class AxisRead : IInputReader<float>
    {
        private string inputName;

        public float Value => Input.GetAxisRaw(inputName);


        public AxisRead(string inputName)
        {
            this.inputName = inputName;
        }
    }
}