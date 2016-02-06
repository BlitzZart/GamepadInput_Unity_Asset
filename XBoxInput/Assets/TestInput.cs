using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour {

    // define input processor
    InputProcessor ip;

	// Use this for initialization
	void Start () {
        
        // intitiate input processor
        ip = new XBox360InputProcessor(0);
	}
	
	// Update is called once per frame
	void Update () {
        ip.ProcessInput();
	}
}
