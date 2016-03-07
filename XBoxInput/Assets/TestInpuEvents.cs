using UnityEngine;
using InputProcessing;
using System;

public class TestInpuEvents : MonoBehaviour {
    VirtualController controller;
    YourGameInput input;

	// Use this for initialization
	void Start () {
        controller = GetComponent<VirtualController>();
        // Decide which kind of input devies is used here.
        input = GetComponent<YourGameInput>();

        input.OnJump += OnJump;
        input.OnPunch += OnPunch;
        input.OnRun += OnRun;
        input.OnStopRunning += OnStopRunning;
	}

    private void OnStopRunning() {
        print("Stop");
    }

    private void OnRun(float value) {
        print("Run: " + value);
    }

    private void OnPunch() {
        print("Punch");

        controller.Vibrate(0.3f, 0.4f, 0.4f);
    }

    private void OnJump() {
        print("Jump");
    }

    void Update() {

    }
}
