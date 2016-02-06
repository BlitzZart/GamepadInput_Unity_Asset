using XInputDotNetPure;
using System.Collections.Generic;

public class ProcessXBoxInput : InputProcessor
{
    public List<XBoxToVirtualButton> buttons;
    public List<XBoxToVirtualAxis> axes;
    private XBox360Input input;

    public ProcessXBoxInput(int playerNumber) : base(playerNumber)
    {
        if (playerNumber < 0)
            playerNumber = 0;
        else if (playerNumber > 3)
            playerNumber = 3;

        input = new XBox360Input(playerNumber);
        buttons = new List<XBoxToVirtualButton>();
        axes = new List<XBoxToVirtualAxis>();

        faceLeft = new VirtualButton();
        faceRight = new VirtualButton();
        faceUp = new VirtualButton();
        faceDown = new VirtualButton();
        shoulderLeft = new VirtualButton();
        shoulderRight = new VirtualButton();
        start = new VirtualButton();
        back = new VirtualButton();
        buttons.Add(new XBoxToVirtualButton(faceLeft, input.buttonX));
        buttons.Add(new XBoxToVirtualButton(faceRight, input.buttonB));
        buttons.Add(new XBoxToVirtualButton(faceUp, input.buttonY));
        buttons.Add(new XBoxToVirtualButton(faceDown, input.buttonA));
        buttons.Add(new XBoxToVirtualButton(shoulderLeft, input.buttonLB));
        buttons.Add(new XBoxToVirtualButton(shoulderRight, input.buttonRB));
        buttons.Add(new XBoxToVirtualButton(start, input.buttonStart));
        buttons.Add(new XBoxToVirtualButton(back, input.buttonBack));

        leftX = new VirtualAxis();
        leftY = new VirtualAxis();
        rightX = new VirtualAxis();
        rightY = new VirtualAxis();
        leftTrigger = new VirtualAxis();
        rightTrigger = new VirtualAxis();
        axes.Add(new XBoxToVirtualAxis(leftX, input.leftStickX));
        axes.Add(new XBoxToVirtualAxis(leftY, input.leftStickY));
        axes.Add(new XBoxToVirtualAxis(rightX, input.rightStickX));
        axes.Add(new XBoxToVirtualAxis(rightY, input.rightStickY));
        axes.Add(new XBoxToVirtualAxis(leftTrigger, input.leftTrigger));
        axes.Add(new XBoxToVirtualAxis(rightTrigger, input.rightTrigger));
    }

    public override void ProcessInput()
    {
        foreach (XBoxToVirtualButton item in buttons)
        {
            if (item.ButtonDelegate() == ButtonState.Pressed)
            {
                if (item.VirtualState == VirtualButtonState.Down)
                    item.VirtualState = VirtualButtonState.Hold;
                else if (item.VirtualState == VirtualButtonState.Released || item.VirtualState == VirtualButtonState.Up)
                    item.VirtualState = VirtualButtonState.Down;
            }
            else if (item.ButtonDelegate() == ButtonState.Released)
            {
                if (item.VirtualState == VirtualButtonState.Up)
                    item.VirtualState = VirtualButtonState.Released;
                else if (item.VirtualState == VirtualButtonState.Hold | item.VirtualState == VirtualButtonState.Down)
                    item.VirtualState = VirtualButtonState.Up;
            }
        }
        for (int i = 0; i < axes.Count; i++)
        {
            axes[i].Process();
        }
    }
}