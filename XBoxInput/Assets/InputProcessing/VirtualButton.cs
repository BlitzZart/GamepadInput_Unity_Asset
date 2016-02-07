using UnityEngine;
using System.Collections;

public enum VirtualButtonState
{
    Down = 0, Hold = 1, Up = 2, Released = 3
}
public class VirtualButton {
    public VirtualButtonState state;
    public VirtualButton()
    {
        state = VirtualButtonState.Released;
    }
}
