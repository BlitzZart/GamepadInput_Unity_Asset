using XInputDotNetPure;
using InputProcessing;
using UnityEngine;
using System;
/// <summary>
/// maps delegates to actual button and axis states of the xbox 360 controller
/// </summary>
public class KeyboardMapping : GamePadMapping {
    public KeyboardMapping(int playerNumber) : base(playerNumber) {
        playerIndex = playerNumber;
        InitializeGamepad();
    }

    private float TwoAxis(KeyCode a, KeyCode b) {
        if (Input.GetKey(a))
            return -1.0f;
        else if (Input.GetKey(b))
            return 1.0f;

        return 0;
    }

    private bool DeadEnd() {
        return false;
    }

    protected override void InitializeGamepad() {
        leftStickY = x => TwoAxis(KeyCode.W, KeyCode.S);
        leftStickX = x => TwoAxis(KeyCode.A, KeyCode.D);
        rightStickY = x => Convert.ToSingle(Input.GetKey(KeyCode.W));
        rightStickX = x => Convert.ToSingle(Input.GetKey(KeyCode.W));

        leftTrigger = x => Convert.ToSingle(Input.GetKey(KeyCode.Q));
        rightTrigger = x => Convert.ToSingle(Input.GetKey(KeyCode.E));

        faceDown = x => Input.GetKey(KeyCode.DownArrow);
        faceRight = x => Input.GetKey(KeyCode.UpArrow);
        faceLeft = x => Input.GetKey(KeyCode.LeftArrow);
        faceUp = x => Input.GetKey(KeyCode.RightArrow);

        buttonDLeft = x => DeadEnd();
        buttonDRight = x => DeadEnd();
        buttonDDown = x => DeadEnd();
        buttonDUP = x => DeadEnd();

        buttonLeftSchoulder = x => DeadEnd();
        buttonRightShoulder = x => DeadEnd();
        buttonLeftTrigger = x => DeadEnd();
        buttonRightTrigger = x => DeadEnd();

        buttonStart = x => Input.GetKey(KeyCode.Return);
        buttonBack = x => Input.GetKey(KeyCode.Escape);
    }
}