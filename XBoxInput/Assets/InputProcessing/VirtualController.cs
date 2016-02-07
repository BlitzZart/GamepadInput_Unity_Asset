using UnityEngine;

namespace InputProcessing {
    /// <summary>
    /// Add this component to player characters.
    /// Call Initialize() on Start().
    /// </summary>
    public class VirtualController : MonoBehaviour {
        private InputProcessor inputProcessor;
        public YourGameInputEvents gameInput;

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