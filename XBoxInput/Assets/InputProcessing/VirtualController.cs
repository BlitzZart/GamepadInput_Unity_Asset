using UnityEngine;
using XInputDotNetPure;

public class VirtualController : MonoBehaviour {
    public InputProcessor inputProcessor;
    public void Initialize(int i)
    {
        inputProcessor = new ProcessXBoxInput(i);
    }
	// Use this for initialization
	void Start () {
    
    }

    // Update is called once per frame
    void Update() {
        inputProcessor.ProcessInput();
        //print(inputBase.start.state);
    }
}
