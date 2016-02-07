using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The class which derives from InputProcessor has to manage all virtual buttons and axes.
/// </summary>
/// 
namespace InputProcessing {
    public abstract class InputProcessor {
        public InputProcessor(int playerNumber) {
            this.playerNumber = playerNumber;
        }
        private int playerNumber;
        public int PlayerNumber { get { return playerNumber; } set { playerNumber = value; } }

        public abstract void Update();

        protected List<DelegateToVirtualButton> buttons;
        protected List<DelegateToVirtualAxis> axes;
        protected GamePadMapping mapping;

        protected VirtualButton faceLeft;
        protected VirtualButton faceRight;
        protected VirtualButton faceDown;
        protected VirtualButton faceUp;
        protected VirtualButton dPadLeft;
        protected VirtualButton dPadRight;
        protected VirtualButton dPadDown;
        protected VirtualButton dPadUp;
        protected VirtualButton shoulderLeft;
        protected VirtualButton shoulderRight;
        protected VirtualButton start;
        protected VirtualButton back;
        protected VirtualAxis leftX;
        protected VirtualAxis leftY;
        protected VirtualAxis rightX;
        protected VirtualAxis rightY;
        protected VirtualAxis leftTrigger;
        protected VirtualAxis rightTrigger;

        public VirtualButton FaceLeft {
            get {
                return faceLeft;
            }
        }
        public VirtualButton FaceRight {
            get {
                return faceRight;
            }
        }
        public VirtualButton FaceDown {
            get {
                return faceDown;
            }
        }
        public VirtualButton FaceUp {
            get {
                return faceUp;
            }
        }
        public VirtualButton DPadLeft {
            get {
                return dPadLeft;
            }
        }
        public VirtualButton DPadRight {
            get {
                return dPadRight;
            }
        }
        public VirtualButton DPadDown {
            get {
                return dPadDown;
            }
        }
        public VirtualButton DPadUp {
            get {
                return dPadUp;
            }
        }
        public VirtualButton ShoulderLeft {
            get {
                return shoulderLeft;
            }
        }
        public VirtualButton ShoulderRight {
            get {
                return shoulderRight;
            }
        }
        public VirtualButton Start {
            get {
                return start;
            }
        }
        public VirtualButton Back {
            get {
                return back;
            }
        }
        public VirtualAxis LeftX {
            get {
                return leftX;
            }
        }
        public VirtualAxis LeftY {
            get {
                return leftY;
            }
        }
        public VirtualAxis RightX {
            get {
                return rightX;
            }
        }
        public VirtualAxis RightY {
            get {
                return rightY;
            }
        }
        public VirtualAxis LeftTrigger {
            get {
                return leftTrigger;
            }
        }
        public VirtualAxis RightTrigger {
            get {
                return rightTrigger;
            }
        }

        /// <summary>
        /// Initialize key mapping before.
        /// </summary>
        protected void InitializeButtonsAndAxes() {

            buttons = new List<DelegateToVirtualButton>();
            axes = new List<DelegateToVirtualAxis>();

            faceLeft = new VirtualButton();
            faceRight = new VirtualButton();
            faceUp = new VirtualButton();
            faceDown = new VirtualButton();
            dPadLeft = new VirtualButton();
            dPadRight = new VirtualButton();
            dPadDown = new VirtualButton();
            dPadUp = new VirtualButton();
            shoulderLeft = new VirtualButton();
            shoulderRight = new VirtualButton();
            start = new VirtualButton();
            back = new VirtualButton();
            buttons.Add(new DelegateToVirtualButton(FaceLeft, mapping.faceLeft));
            buttons.Add(new DelegateToVirtualButton(FaceRight, mapping.faceRight));
            buttons.Add(new DelegateToVirtualButton(FaceUp, mapping.faceUp));
            buttons.Add(new DelegateToVirtualButton(FaceDown, mapping.faceDown));
            buttons.Add(new DelegateToVirtualButton(DPadLeft, mapping.buttonDLeft));
            buttons.Add(new DelegateToVirtualButton(DPadRight, mapping.buttonDRight));
            buttons.Add(new DelegateToVirtualButton(DPadDown, mapping.buttonDDown));
            buttons.Add(new DelegateToVirtualButton(DPadUp, mapping.buttonDUP));
            buttons.Add(new DelegateToVirtualButton(ShoulderLeft, mapping.buttonLeftSchoulder));
            buttons.Add(new DelegateToVirtualButton(ShoulderRight, mapping.buttonRightShoulder));
            buttons.Add(new DelegateToVirtualButton(Start, mapping.buttonStart));
            buttons.Add(new DelegateToVirtualButton(Back, mapping.buttonBack));

            leftX = new VirtualAxis();
            leftY = new VirtualAxis();
            rightX = new VirtualAxis();
            rightY = new VirtualAxis();
            leftTrigger = new VirtualAxis();
            rightTrigger = new VirtualAxis();
            axes.Add(new DelegateToVirtualAxis(LeftX, mapping.leftStickX));
            axes.Add(new DelegateToVirtualAxis(LeftY, mapping.leftStickY));
            axes.Add(new DelegateToVirtualAxis(RightX, mapping.rightStickX));
            axes.Add(new DelegateToVirtualAxis(RightY, mapping.rightStickY));
            axes.Add(new DelegateToVirtualAxis(LeftTrigger, mapping.leftTrigger));
            axes.Add(new DelegateToVirtualAxis(RightTrigger, mapping.rightTrigger));
        }
    }
}