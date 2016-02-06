using System;

namespace Controlls {
    public class KeyBinding_GravityOnStomp : KeyBinding {

        public KeyBinding_GravityOnStomp(int playerNumber, VirtualController controller) : base(controller) {
            controller.Initialize(playerNumber);
        }
        public override bool Jump() {
            if (controller.inputProcessor.faceDown.state == VirtualButtonState.Down) {
                return true;
            }
            return false;
        }
        public override bool Stomp() {
            return controller.inputProcessor.faceLeft.state == VirtualButtonState.Hold;
        }
        public override bool StartStomp()
        {
            return controller.inputProcessor.faceLeft.state == VirtualButtonState.Down;
        }
        public override float Move() {
            return controller.inputProcessor.leftX.value;
        }
    }
}