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


        public IInputReader<float> Vertical => vertical;
        public IInputReader<float> Horizontal => horizontal;

        // Will need editing, there is diffrence between small and large jump
        public IInputReader<bool> Jump => jumpRead;
        public IInputReader<bool> IsGliding => glidingRead;
        public IInputReader<bool> IsRunning => isSprintingRead;
        public IInputReader<bool> LayEgg => layEggRead;


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
