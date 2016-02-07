using XInputDotNetPure;
using InputProcessing;
/// <summary>
/// maps delegates to actual button and axis states of the xbox 360 controller
/// </summary>
public class XBox360Mapping : GamePadMapping {
    public XBox360Mapping(int playerNumber) : base(playerNumber) {
        playerIndex = playerNumber;
        InitializeGamepad();
    }

    private bool BtnStateToBool(ButtonState state) {
        return state == ButtonState.Pressed;
    }

    protected override void InitializeGamepad() {
        leftStickY = x => GamePad.GetState((PlayerIndex)playerIndex).ThumbSticks.Left.Y;
        leftStickX = x => GamePad.GetState((PlayerIndex)playerIndex).ThumbSticks.Left.X;
        rightStickY = x => GamePad.GetState((PlayerIndex)playerIndex).ThumbSticks.Right.Y;
        rightStickX = x => GamePad.GetState((PlayerIndex)playerIndex).ThumbSticks.Right.X;

        leftTrigger = x => GamePad.GetState((PlayerIndex)playerIndex).Triggers.Left;
        rightTrigger = x => GamePad.GetState((PlayerIndex)playerIndex).Triggers.Right;

        faceDown = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.A);
        faceRight = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.B);
        faceLeft = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.X);
        faceUp = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.Y);

        buttonDLeft = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).DPad.Left);
        buttonDRight = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).DPad.Right);
        buttonDDown = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).DPad.Down);
        buttonDUP = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).DPad.Up);

        buttonLeftSchoulder = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.LeftShoulder);
        buttonRightShoulder = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.RightShoulder);
        buttonLeftTrigger = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.LeftShoulder);
        buttonRightTrigger = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.RightShoulder);

        buttonStart = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.Start);
        buttonBack = x => BtnStateToBool(GamePad.GetState((PlayerIndex)playerIndex).Buttons.Back);
    }
}