using UnityEngine;

namespace Controlls {
    public abstract class KeyBinding {
        protected VirtualController controller;

        public KeyBinding(VirtualController controller) {
            this.controller = controller;
        }
        public abstract bool Jump();
        public abstract bool StartStomp();
        public abstract bool Stomp();
        public abstract float Move();
    }
}