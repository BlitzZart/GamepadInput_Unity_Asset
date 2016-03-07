using System.Collections.Generic;

namespace InputProcessing {

    /// <summary>
    /// maps delegates to actual button and axis states of an abstract gamepad
    /// </summary>
    public abstract class GamePadMapping {
        public delegate float SticksDel(float f = 1);
        public SticksDel leftStickY, leftStickX, rightStickX, rightStickY, rightTrigger, leftTrigger;
        public delegate bool ButtonDelegate(bool b = true);
        public ButtonDelegate faceDown, faceRight, faceLeft, faceUp,
            buttonDLeft, buttonDRight, buttonDDown, buttonDUP,
            buttonLeftSchoulder, buttonRightShoulder, buttonLeftTrigger, buttonRightTrigger,
            buttonStart, buttonBack;

        protected int playerIndex;

        public GamePadMapping(int playerNumber) {
            playerIndex = playerNumber;
            InitializeGamepad();
        }

        protected abstract void InitializeGamepad();
    }
}