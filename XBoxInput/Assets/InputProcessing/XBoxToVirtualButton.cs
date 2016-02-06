using UnityEngine;
using System.Collections;

public class XBoxToVirtualButton {
    private VirtualButton virtualButton;
    public VirtualButtonState VirtualState { get { return virtualButton.state; } set { virtualButton.state = value; } }
    private XBox360Input.ButtonDelegate buttonDelegate;

    public XBox360Input.ButtonDelegate ButtonDelegate { get { return buttonDelegate; } }

    public XBoxToVirtualButton(VirtualButton virtualButton, XBox360Input.ButtonDelegate buttonDelegate)
    {
        this.virtualButton = virtualButton;
        this.buttonDelegate = buttonDelegate;
    }
}