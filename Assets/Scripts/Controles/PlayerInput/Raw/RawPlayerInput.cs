using CG.Scripts.Controles.InputReader;


namespace CG.Scripts.Controles.PlayerInput
{
    public class RawPlayerInput : IRawPlayerInput
    {
        private IInputReader<bool> jumpRead;
        private IInputReader<bool> glidingRead;
        private IInputReader<bool> isSprintingRead;
        private IInputReader<bool> layEggRead;

        private IInputReader<float> vertical;
        private IInputReader<float> horizontal;


        // Will need editing, there is diffrence between small and large jump
        public bool Jump => jumpRead.Value;
        public bool IsGliding => glidingRead.Value;
        public bool IsRunning => isSprintingRead.Value;
        public bool LayEgg => layEggRead.Value;

        public float Vertical => vertical.Value;
        public float Horizontal => horizontal.Value;


        public RawPlayerInput(
            string jumpKey = InputContoleNames.SPACE,
            string glidingKey = InputContoleNames.SPACE,
            string sprintKey = InputContoleNames.SHIFT,
            string layEggKey = InputContoleNames.E,
            string verticalKey = InputContoleNames.VERTICAL,
            string horizontalKey = InputContoleNames.HORIZONTAL)
        {
            jumpRead = new ButtonDownRead(jumpKey);
            glidingRead = new ButtonDownRead(glidingKey);
            isSprintingRead = new ButtonRead(sprintKey);
            layEggRead = new ButtonDownRead(layEggKey);
            vertical = new AxisRead(verticalKey);
            horizontal = new AxisRead(horizontalKey);
        }
    }
}
