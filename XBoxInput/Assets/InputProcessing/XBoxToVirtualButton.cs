using UnityEngine;
using System.Collections;

public class XBoxToVirtualButton {
    private VirtualButton virtualButton;
    public VirtualButtonState VirtualState { get { return virtualButton.state; } set { virtualButton.state = value; } }
    private XBox360Mapping.ButtonDelegate buttonDelegate;

    public XBox360Mapping.ButtonDelegate ButtonDelegate { get { return buttonDelegate; } }

    public XBoxToVirtualButton(VirtualButton virtualButton, XBox360Mapping.ButtonDelegate buttonDelegate)
    {
        this.virtualButton = virtualButton;
        this.buttonDelegate = buttonDelegate;
    }
}