using System.Collections.Generic;
using UnityEngine;

namespace InputProcessing {
    public enum InputKey {
        FaceDown = 0, FaceRight = 1, FaceLeft = 2, FaceUp = 3,
        DPadDown = 4, DPadRight = 5, DPadLeft = 6, DPadUp = 7,
        ShoulderLeft = 8, ShoulderRight = 9,
        Start, Back 
    }

    public enum InputAxis {
        XLeft = 0, YLeft = 1, XRight = 2, YRight = 3,
        LeftTrigger, RightTrigger
    }

    /// <summary>
    /// Add this component to player characters.
    /// Call Initialize() on Start().
    /// </summary>
    public class VirtualController : MonoBehaviour {
        private InputProcessor inputProcessor;
        private Dictionary<InputKey, VirtualButton> virtualKeys;
        public Dictionary<InputKey, VirtualButton> VirtualKeys { get { return virtualKeys; } }
        private Dictionary<InputAxis, VirtualAxis> virtualInputAxis;
        public Dictionary<InputAxis, VirtualAxis> VirtualInputAxis { get { return virtualInputAxis; } }

        public InputProcessor ip {
            get {
                return inputProcessor;
            }

            set {
                inputProcessor = value;
            }
        }

        public void Initialize(InputProcessor inputProcessor) {
            ip = inputProcessor;

            // MonoBehavior is needed to use Coroutines withn the InputProcessor
            if (this.inputProcessor is IVibration)
                (this.inputProcessor as IVibration).SetMonoBehaviour(this);

            InitializeDictionaries();
        }

        private void InitializeDictionaries() {
            virtualKeys = new Dictionary<InputKey, VirtualButton>();
            virtualKeys.Add(InputKey.FaceDown, ip.FaceDown);
            virtualKeys.Add(InputKey.FaceRight, ip.FaceRight);
            virtualKeys.Add(InputKey.FaceLeft, ip.FaceLeft);
            virtualKeys.Add(InputKey.FaceUp, ip.FaceUp);

            virtualKeys.Add(InputKey.DPadDown, ip.DPadDown);
            virtualKeys.Add(InputKey.DPadRight, ip.DPadRight);
            virtualKeys.Add(InputKey.DPadLeft, ip.DPadLeft);
            virtualKeys.Add(InputKey.DPadUp, ip.DPadUp);

            virtualKeys.Add(InputKey.ShoulderLeft, ip.ShoulderLeft);
            virtualKeys.Add(InputKey.ShoulderRight, ip.ShoulderRight);

            virtualKeys.Add(InputKey.Start, ip.Start);
            virtualKeys.Add(InputKey.Back, ip.Back);

            virtualInputAxis = new Dictionary<InputAxis, VirtualAxis>();
            virtualInputAxis.Add(InputAxis.XLeft, ip.LeftX);
            virtualInputAxis.Add(InputAxis.YLeft, ip.LeftY);
            virtualInputAxis.Add(InputAxis.XRight, ip.RightX);
            virtualInputAxis.Add(InputAxis.YRight, ip.RightY);

            virtualInputAxis.Add(InputAxis.RightTrigger, ip.RightTrigger);
            virtualInputAxis.Add(InputAxis.LeftTrigger, ip.LeftTrigger);
        }

        public void Vibrate(float duration, float leftStrength, float rightStrenght) {
            if (inputProcessor is IVibration)
                (inputProcessor as IVibration).Vibrate(duration, leftStrength, rightStrenght);
        }
        public void SetPlayerNumber(int playerNumber) {
            ip.PlayerNumber = playerNumber;
        }
        // All input gets updated here.
        void Update() {
            ip.Update();
        }
    }
}