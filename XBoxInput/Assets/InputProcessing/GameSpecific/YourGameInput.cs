using System.Collections.Generic;
using UnityEngine;

namespace InputProcessing {
    
    /// <summary>
    /// Fire events depending on key input
    /// </summary>
    public class YourGameInput : MonoBehaviour{


        public InputKey Jump;
        public InputKey Punch;

        public InputAxis Run;

        public delegate void InputDelegate();
        public event InputDelegate OnJump, OnPunch, OnStopRunning;

        public delegate void InputAxisDelegate(float value);
        public event InputAxisDelegate OnRun;

        public float deadZone = 0.1f;

        private VirtualController controller;

        void Start() {
            controller = GetComponent<VirtualController>();
            controller.Initialize(new XBox360InputProcessor(0));
        }

        private bool isRunning;

        public void Update() {
            if (controller.VirtualKeys == null)
                return;
            if (controller.VirtualKeys[Jump].state == VirtualButtonState.Down)
                if (OnJump != null)
                    OnJump();

            if (controller.VirtualKeys[Punch].state == VirtualButtonState.Down)
                if (OnPunch != null)
                    OnPunch();

            // check if player stopped
            if (isRunning) {
                if (Mathf.Abs(controller.VirtualInputAxis[Run].value) <= deadZone) {
                    if (OnRun != null) // fire event with speed zero once
                        OnRun(0);

                    if (OnStopRunning != null) // fire event - player stopped
                        OnStopRunning();
                }
                isRunning = false;
            }

            if (Mathf.Abs(controller.VirtualInputAxis[Run].value) > deadZone) {
                if (OnRun != null)
                    OnRun(controller.ip.LeftX.value);

                isRunning = true;
            }
        }
    }
}