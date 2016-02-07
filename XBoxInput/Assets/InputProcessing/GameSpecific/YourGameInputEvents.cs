using UnityEngine;

namespace InputProcessing {
    /// <summary>
    /// Fire events depending on key input
    /// </summary>
    public class YourGameInputEvents {
        public delegate void InputDelegate();
        public event InputDelegate OnJump, OnPunch, OnStopRunning;

        public delegate void InputAxisDelegate(float value);
        public event InputAxisDelegate OnRun;

        public float deadZone = 0.1f;

        private VirtualController vc;
        public YourGameInputEvents(VirtualController vc) {
            this.vc = vc;
        }

        private bool isRunning;

        public void Update() {
            if (vc.ip.FaceDown.state == VirtualButtonState.Down)
                if (OnJump != null)
                    OnJump();

            if (vc.ip.FaceLeft.state == VirtualButtonState.Down)
                if (OnPunch != null)
                    OnPunch();

            // check if player stopped
            if (isRunning) {
                if (Mathf.Abs(vc.ip.LeftX.value) <= deadZone) {
                    if (OnStopRunning != null) // fire event - player stopped
                        OnStopRunning();

                    if (OnRun != null) // fire event with speed zero once
                        OnRun(0);
                }
                isRunning = false;
            }

            if (Mathf.Abs(vc.ip.LeftX.value) > deadZone) {
                if (OnRun != null)
                    OnRun(vc.ip.LeftX.value);

                isRunning = true;
            }
        }
    }
}