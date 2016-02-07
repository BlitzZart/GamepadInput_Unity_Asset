using InputProcessing;
using UnityEngine;

/// <summary>
/// Decoupling of InputProcessor from actual game actions
/// </summary>
public class YourGameInputCyclic {

    private float deadZone = 0.1f;
    public float DeadZone {
        get {
            return deadZone;
        }

        set {
            deadZone = value;
        }
    }
    protected VirtualController controller;

    public YourGameInputCyclic(VirtualController controller) {
        this.controller = controller;
    }
    public float Move() {
        if (Mathf.Abs(controller.ip.LeftX.value) < DeadZone)
            return 0;

        return controller.ip.LeftX.value;

    }
    public bool Jump() {
        if (controller.ip.FaceDown.state != VirtualButtonState.Down)
            return false;

        controller.Vibrate(0.1f, 0.66f, 0.66f);
        return true;
    }

    public bool Hold() {
        return controller.ip.DPadDown.state == VirtualButtonState.Hold;
    }

}