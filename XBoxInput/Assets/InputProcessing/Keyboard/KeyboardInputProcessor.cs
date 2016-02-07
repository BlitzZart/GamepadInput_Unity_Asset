using XInputDotNetPure;
using InputProcessing;
using UnityEngine;

public class KeyboardInputProcessor : InputProcessor {
    /// <summary>
    /// Input processor for a XBox360 gamepad using XInputDotNetPure.dll.
    /// The XBox button states are transfered to the virtual controller ones.
    /// </summary>
    /// <param name="playerNumber"></param>
    public KeyboardInputProcessor(int playerNumber) : base(playerNumber) {
        if (playerNumber < 0)
            playerNumber = 0;
        else if (playerNumber > 3)
            playerNumber = 3;

        mapping = new KeyboardMapping(playerNumber);
        InitializeButtonsAndAxes();
    }

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
}