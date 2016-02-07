using UnityEngine;
using InputProcessing;

public class TestInputCyclic : MonoBehaviour {
    VirtualController controller;
    YourGameInputCyclic input;

	// Use this for initialization
	void Start () {
        controller = GetComponent<VirtualController>();
        controller.Initialize(new XBox360InputProcessor(0));

        input = new YourGameInputCyclic(controller);
	}
	
	// Update is called once per frame
	void Update () {
        print(input.Jump());
        print(input.Hold());
        print(input.Move());
	}
}
