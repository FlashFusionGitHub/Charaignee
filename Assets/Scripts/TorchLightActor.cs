using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class TorchLightActor : MonoBehaviour {

    private Light torchLight;
    private InputDevice gamePad;

    // Use this for initialization
    void Start () {
        torchLight = gameObject.GetComponent<Light>();
        gamePad = InputManager.ActiveDevice;
    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_PS4
        if(gamePad.Action3.WasPressed)
                TorchOnOff();
#endif
        if (Input.GetKeyDown(KeyCode.F))
            TorchOnOff();
    }

    private void TorchOnOff() {
       switch (torchLight.enabled == false)
       {
           case true:
               torchLight.enabled = true;
               break;
           case false:
               torchLight.enabled = false;
               break;
       }
    }
}
