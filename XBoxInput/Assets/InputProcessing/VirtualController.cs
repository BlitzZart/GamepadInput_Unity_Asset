using UnityEngine;
using XInputDotNetPure;

public class VirtualController : MonoBehaviour {
    private InputProcessor inputProcessor;
    public InputProcessor InputProcessor {
        get {
            return inputProcessor;
        }

        set {
            inputProcessor = value;
        }
    }

    public void Initialize(int i)
    {
        InputProcessor = new XBox360InputProcessor(i);
    }

    void Update() {
        InputProcessor.ProcessInput();
    }
}
