namespace InputProcessing {
    /// <summary>
    /// mapping between virtual axis and delegate of control stick
    /// </summary>
    public class DelegateToVirtualAxis {
        private VirtualAxis virtualAxis;
        private GamePadMapping.SticksDel stickDelegate;

        public DelegateToVirtualAxis(VirtualAxis virtualAxis, GamePadMapping.SticksDel stickDelegate) {
            this.virtualAxis = virtualAxis;
            this.stickDelegate = stickDelegate;
        }
        public void Process() {
            virtualAxis.value = stickDelegate();
        }
    }
}