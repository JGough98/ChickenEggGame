using CG.Scripts.Controles.InputReader;


namespace CG.Scripts.Controles.PlayerInput
{
    public class PlayerInput : IPlayerInput
    {
        private IInputReader<bool> jumpRead;
        private IInputReader<bool> glidingRead;
        private IInputReader<bool> isSprintingRead;
        private IInputReader<bool> layEggRead;

        private IInputReader<float> moveUp;
        private IInputReader<float> moveDown;
        private IInputReader<float> moveLeft;
        private IInputReader<float> moveRight;


        // Will need editing, there is diffrence between small and large jump
        public bool Jump => jumpRead.Value;
        public bool IsGliding => glidingRead.Value;
        public bool IsRunning => isSprintingRead.Value;
        public bool LayEgg => layEggRead.Value;

        public float Up => moveUp.Value;
        public float Down => moveDown.Value;
        public float Left => moveLeft.Value;
        public float Right => moveRight.Value;


        public PlayerInput(
            string jumpKey = InputContoleNames.SPACE,
            string glidingKey = InputContoleNames.SPACE,
            string sprintKey = InputContoleNames.SHIFT,
            string layEggKey = InputContoleNames.E,
            string moveUpKey = InputContoleNames.UP,
            string moveDownKey = InputContoleNames.DOWN,
            string moveLeftKey = InputContoleNames.LEFT,
            string moveRightKey = InputContoleNames.RIGHT)
        {
            jumpRead = new ButtonDownRead(jumpKey);
            glidingRead = new ButtonDownRead(glidingKey);
            isSprintingRead = new ButtonRead(sprintKey);
            layEggRead = new ButtonDownRead(layEggKey);
            moveUp = new AxisRead(moveUpKey);
            moveDown = new AxisRead(moveDownKey);
            moveLeft = new AxisRead(moveLeftKey);
            moveRight = new AxisRead(moveRightKey);
        }
    }
}
