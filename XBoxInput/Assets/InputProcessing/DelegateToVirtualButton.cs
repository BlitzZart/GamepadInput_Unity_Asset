namespace InputProcessing {
    /// <summary>
    /// mapping between virtual button and delegate of controller button
    /// stores the button state
    /// </summary>
    public class DelegateToVirtualButton {
        private VirtualButton virtualButton;
        public VirtualButtonState VirtualState { get { return virtualButton.state; } set { virtualButton.state = value; } }
        private GamePadMapping.ButtonDelegate buttonDelegate;

        public GamePadMapping.ButtonDelegate ButtonDelegate { get { return buttonDelegate; } }

        public DelegateToVirtualButton(VirtualButton virtualButton, GamePadMapping.ButtonDelegate buttonDelegate) {
            this.virtualButton = virtualButton;
            this.buttonDelegate = buttonDelegate;
        }
    }
}