using UnityEngine;
using System.Collections;

public class XBoxToVirtualAxis {
    private VirtualAxis virtualAxis;
    private XBox360Input.SticksDel stickDelegate;

    public XBoxToVirtualAxis(VirtualAxis virtualAxis, XBox360Input.SticksDel stickDelegate)
    {
        this.virtualAxis = virtualAxis;
        this.stickDelegate = stickDelegate;
    }
    public void Process()
    {
        virtualAxis.value = stickDelegate();
    }

}
