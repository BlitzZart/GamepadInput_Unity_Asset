using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using System;


namespace PlayerController
{
    public class PlayerInput : MonoBehaviour
    {

        public int playerNumber = 0;
        private int gampadPlayer = 0;
        private int keyboardPlayer = 0;

        //[HideInInspector]
        public InputMode playerInputMode;

        public enum InputMode
        {
            Keyboard, Gamepad
        }

        public enum InputStates
        {
            UP, DOWN, LEFT, RIGHT, RS_UP, RS_DOWN, RS_LEFT, RS_RIGHT, A, B, X, Y, LB, LT, RB, RT, BACK, START
        }

        bool relA, relB, relX, relY, relLB, relRB = false;

        List<InputStates> holdableKeys; // defindes list with keys which get not reset at begin of inputcheck

        public Dictionary<InputStates, bool> userInputs; // stores current input state
        float axisDeadPoint = 0.2f; // minimum input value (e.g. from analog joystick)
        float yAxisValue, xAxisValue = 0;


        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {
            // holdableKeys = new List<InputStates>();
            //  holdableKeys.Add(InputStates.A); // TODO add from outside (client)
            //KeyBinding();

            userInputs = new Dictionary<InputStates, bool>();

            foreach (InputStates key in Enum.GetValues(typeof(InputStates)))
            {
                userInputs.Add(key, false);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            GetPlayerInput();
        }

        private KeyCode upKey, downKey, leftKey, rightKey, rUpKey, rDownKey, rLeftKey, rRightKey, aKey, bKey, xKey, yKey, lbKey, rbKey, startKey, backKey;
        void GetPlayerInput()
        {
            foreach (InputStates key in Enum.GetValues(typeof(InputStates)))
            {
                // if (!holdableKeys.Contains(key)) // only reset if not a holdable key
                userInputs[key] = false;
            }
            xAxisValue = 0;

            switch (playerInputMode)
            {
                case InputMode.Keyboard:

                    if (Input.GetKey(upKey))
                    {
                        userInputs[InputStates.UP] = true;
                        //userInputs[InputStates.A] = true; // TODO flexible binding
                    }
                    else if (Input.GetKey(downKey))
                    {
                        userInputs[InputStates.DOWN] = true;
                    }
                    if (Input.GetKey(leftKey))
                        xAxisValue = -1;


                    if (Input.GetKey(rightKey))
                        xAxisValue = 1;


                    if (Input.GetKey(leftKey))
                    {
                        userInputs[InputStates.LEFT] = true;
                    }
                    else if (Input.GetKey(rightKey))
                    {
                        userInputs[InputStates.RIGHT] = true;
                    }


                    if (Input.GetKey(rUpKey))
                    {
                        userInputs[InputStates.RS_UP] = true;
                    }
                    else if (Input.GetKey(rDownKey))
                    {
                        userInputs[InputStates.RS_DOWN] = true;
                    }
                    if (Input.GetKey(rLeftKey))
                    {
                        userInputs[InputStates.RS_LEFT] = true;
                    }
                    else if (Input.GetKey(rRightKey))
                    {
                        userInputs[InputStates.RS_RIGHT] = true;
                    }

                    if (Input.anyKeyDown)
                    {

                        if (Input.GetKey(aKey) || Input.GetKey(upKey))
                        {
                            userInputs[InputStates.A] = true;
                        }
                        if (Input.GetKey(bKey))
                        {
                            userInputs[InputStates.B] = true;
                        }
                        if (Input.GetKey(xKey))
                        {
                            userInputs[InputStates.X] = true;
                        }
                        if (Input.GetKey(yKey))
                        {
                            userInputs[InputStates.Y] = true;
                        }

                        if (Input.GetKey(lbKey))
                        {
                            userInputs[InputStates.LB] = true;
                        }
                        if (Input.GetKey(rbKey))
                        {
                            userInputs[InputStates.RB] = true;
                        }

                        if (Input.GetKey(startKey))
                        {
                            userInputs[InputStates.START] = true;
                        }
                        if (Input.GetKey(backKey))
                        {
                            userInputs[InputStates.BACK] = true;
                        }
                    }
                    break;
                case InputMode.Gamepad:
                    if (leftStickX() > axisDeadPoint || leftStickX() < -axisDeadPoint)
                        xAxisValue = leftStickX();
                    else
                        xAxisValue = 0;

                    if (leftStickY() > axisDeadPoint)
                    {
                        userInputs[InputStates.UP] = true;
                    }
                    else if (leftStickY() < -axisDeadPoint)
                    {
                        userInputs[InputStates.DOWN] = true;
                    }
                    if (leftStickX() > axisDeadPoint)
                    {
                        userInputs[InputStates.RIGHT] = true;
                    }
                    else if (leftStickX() < -axisDeadPoint)
                    {
                        userInputs[InputStates.LEFT] = true;
                    }

                    if (rightStickY() > axisDeadPoint)
                    {
                        userInputs[InputStates.RS_UP] = true;
                    }
                    else if (rightStickY() < -axisDeadPoint)
                    {
                        userInputs[InputStates.RS_DOWN] = true;
                    }
                    if (rightStickX() > axisDeadPoint)
                    {
                        userInputs[InputStates.RS_RIGHT] = true;
                    }
                    else if (rightStickX() < -axisDeadPoint)
                    {
                        userInputs[InputStates.RS_LEFT] = true;
                    }

                    // ------------------------------------------------
                    // ------------------------------------------------
                    if (buttonA() == ButtonState.Released)
                    {
                        relA = true;
                    }
                    if (buttonA() == ButtonState.Pressed && relA)
                    {
                        userInputs[InputStates.A] = true;
                        relA = false;
                    }

                    //if (buttonB() == ButtonState.Released)
                    //{
                    //    relB = true;
                    //}
                    if (buttonB() == ButtonState.Pressed /* && relB*/)
                    {
                        userInputs[InputStates.B] = true;
                        //relB = false;
                    }
                    if (buttonX() == ButtonState.Released)
                    {
                        relX = true;
                    }
                    if (buttonX() == ButtonState.Pressed && relX)
                    {
                        userInputs[InputStates.X] = true;
                        relX = false;
                    }
                    if (buttonY() == ButtonState.Released)
                    {
                        relY = true;
                    }
                    if (buttonY() == ButtonState.Pressed && relY)
                    {
                        userInputs[InputStates.Y] = true;
                        relY = false;
                    }
                    if (buttonLB() == ButtonState.Released)
                    {
                        relLB = true;
                    }
                    if (buttonLB() == ButtonState.Pressed && relLB)
                    {
                        userInputs[InputStates.LB] = true;
                        relLB = false;
                    }
                    if (buttonRB() == ButtonState.Released)
                    {
                        relRB = true;
                    }
                    if (buttonRB() == ButtonState.Pressed && relRB)
                    {
                        userInputs[InputStates.RB] = true;
                        relRB = false;
                    }
                    // ------------------------------------------------
                    // ------------------------------------------------
                    if (buttonStart() == ButtonState.Pressed)
                    {
                        userInputs[InputStates.START] = true;
                    }
                    if (buttonBack() == ButtonState.Pressed)
                    {
                        userInputs[InputStates.BACK] = true;
                    }
                    break;
            }

            // actual caracter input
            if (!Application.loadedLevelName.Contains("tradingScreen"))
            {

            }
            else
            {

                // trade navigation controlls
                if (leftOff && userInputs[InputStates.LEFT])
                {
                    leftTrade = true;
                    leftOff = false;
                }
                if (!userInputs[InputStates.LEFT])
                    leftOff = true;

                if (rightOff && userInputs[InputStates.RIGHT])
                {
                    rightTrade = true;
                    rightOff = false;
                }
                if (!userInputs[InputStates.RIGHT])
                    rightOff = true;

                leftTrade = rightTrade = false;
            }

        }
        bool leftTrade, leftOff,
                rightTrade, rightOff = false;

        // fakes stick values if input mode is keyboard
        // only needed if PlayerController uses sticks without checking(mode has to be GamePad)
        public void fakeLeftStick()
        {
            leftStickY = x => fakeLeftY(1);
            leftStickX = x => fakeLeftX(1);
        }
        public float fakeLeftY(float a)
        {
            if (userInputs[InputStates.UP])
                return 1;
            else if (userInputs[InputStates.DOWN])
                return -1;

            return 0;
        }
        public float fakeLeftX(float a)
        {
            if (userInputs[InputStates.LEFT])
                return -1;
            else if (userInputs[InputStates.RIGHT])
                return 1;

            return 0;
        }


        public delegate float sticksDel(float f = 1);
        public sticksDel leftStickY, leftStickX, rightStickX, rightStickY;
        delegate ButtonState buttonDel(bool b = true);
        buttonDel buttonA, buttonB, buttonX, buttonY,
            buttonLB, buttonRB, buttonLT, buttonRT,
            buttonStart, buttonBack;


       

        PlayerIndex curPlayer;// = PlayerIndex.One;
        //--
        public void KeyBinding()
        {
            if (playerInputMode == InputMode.Keyboard)
            {
                switch (keyboardPlayer)
                {
                    case 1:
                        upKey = KeyCode.W;
                        downKey = KeyCode.S;
                        leftKey = KeyCode.A;
                        rightKey = KeyCode.D;

                        rUpKey = KeyCode.UpArrow;
                        rDownKey = KeyCode.DownArrow;
                        rLeftKey = KeyCode.LeftArrow;
                        rRightKey = KeyCode.RightArrow;

                        startKey = KeyCode.Escape;

                        aKey = KeyCode.RightShift;
                        rbKey = KeyCode.RightControl;
                        break;
                        //case 2:
                        //    upKey = KeyCode.UpArrow;
                        //    downKey = KeyCode.DownArrow;
                        //    leftKey = KeyCode.LeftArrow;
                        //    rightKey = KeyCode.RightArrow;
                        //    rbKey = KeyCode.RightControl;
                        //    startKey = KeyCode.Escape;
                        //    break;
                }
                fakeLeftStick();
            }
            else if (playerInputMode == InputMode.Gamepad)
            {
                switch (gampadPlayer)
                {
                    case 1:
                        curPlayer = PlayerIndex.One;
                        break;
                    case 2:
                        curPlayer = PlayerIndex.Two;
                        break;
                    case 3:
                        curPlayer = PlayerIndex.Three;
                        break;
                    case 4:
                        curPlayer = PlayerIndex.Four;
                        break;
                }

                //GamePad.GetState(curPlayer).Triggers.

                leftStickY = x => GamePad.GetState(curPlayer).ThumbSticks.Left.Y;
                leftStickX = x => GamePad.GetState(curPlayer).ThumbSticks.Left.X;
                rightStickY = x => GamePad.GetState(curPlayer).ThumbSticks.Right.Y;
                rightStickX = x => GamePad.GetState(curPlayer).ThumbSticks.Right.X;
                buttonA = x => GamePad.GetState(curPlayer).Buttons.A;
                buttonB = x => GamePad.GetState(curPlayer).Buttons.B;
                buttonX = x => GamePad.GetState(curPlayer).Buttons.X;
                buttonY = x => GamePad.GetState(curPlayer).Buttons.Y;

                buttonLB = x => GamePad.GetState(curPlayer).Buttons.LeftShoulder;
                buttonRB = x => GamePad.GetState(curPlayer).Buttons.RightShoulder;
                buttonLT = x => GamePad.GetState(curPlayer).Buttons.LeftShoulder;
                buttonRT = x => GamePad.GetState(curPlayer).Buttons.RightShoulder;

                buttonStart = x => GamePad.GetState(curPlayer).Buttons.Start;
                buttonBack = x => GamePad.GetState(curPlayer).Buttons.Back;
            }
        }
    }
}