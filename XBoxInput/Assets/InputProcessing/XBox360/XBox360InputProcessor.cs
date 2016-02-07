using System.Collections;
using InputProcessing;
using XInputDotNetPure;
using UnityEngine;

/// <summary>
/// Input processor for a XBox360 gamepad using XInputDotNetPure.dll.
/// The XBox button states are transfered to the virtual controller ones.
/// </summary>
public class XBox360InputProcessor : InputProcessor, IVibration{
    private MonoBehaviour virtualController;
    public XBox360InputProcessor(int playerNumber) : base(playerNumber) {
        if (playerNumber < 0)
            playerNumber = 0;
        else if (playerNumber > 3)
            playerNumber = 3;

        mapping = new XBox360Mapping(playerNumber);
        InitializeButtonsAndAxes();
    }

    /// <summary>
    /// Precessing input by iteration over all buttons and axes
    /// and interpreting buttonstates.
    /// </summary>
    public override void Update() {
        foreach (DelegateToVirtualButton item in buttons) {
            if (item.ButtonDelegate()) { // button is held
                if (item.VirtualState == VirtualButtonState.Down)
                    item.VirtualState = VirtualButtonState.Hold;
                else if (item.VirtualState == VirtualButtonState.Released || item.VirtualState == VirtualButtonState.Up)
                    item.VirtualState = VirtualButtonState.Down;
            }
            else if (!item.ButtonDelegate()) { // button is released
                if (item.VirtualState == VirtualButtonState.Up)
                    item.VirtualState = VirtualButtonState.Released;
                else if (item.VirtualState == VirtualButtonState.Hold | item.VirtualState == VirtualButtonState.Down)
                    item.VirtualState = VirtualButtonState.Up;
            }
        }
        for (int i = 0; i < axes.Count; i++) {
            axes[i].Process();
        }
    }

    //--------------------------------Vibration--------------------------------
    public void SetMonoBehaviour(MonoBehaviour virtualController) {
        this.virtualController = virtualController;
    }
    public void Vibrate(float duration, float leftStrength, float rightStrenght) {
        GamePad.SetVibration((PlayerIndex)PlayerNumber, leftStrength, rightStrenght);
        virtualController.StartCoroutine(StopVibration(duration));
    }
    public IEnumerator StopVibration(float delay) {
        yield return new WaitForSeconds(delay);
        GamePad.SetVibration((PlayerIndex)PlayerNumber, 0, 0);
    }
}