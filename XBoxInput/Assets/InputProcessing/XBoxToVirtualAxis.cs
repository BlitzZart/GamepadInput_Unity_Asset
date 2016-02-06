using UnityEngine;
using System.Collections;

public class XBoxToVirtualAxis {
    private VirtualAxis virtualAxis;
    private XBox360Mapping.SticksDel stickDelegate;

    public XBoxToVirtualAxis(VirtualAxis virtualAxis, XBox360Mapping.SticksDel stickDelegate)
    {
        this.virtualAxis = virtualAxis;
        this.stickDelegate = stickDelegate;
    }
    public void Process()
    {
        virtualAxis.value = stickDelegate();
    }

}
