using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTurn : MonoBehaviour {

    public float turnSpeed = 1;
    public float maximumAngle = 90;
    public float minimumAngle = 90;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 turnAmount = new Vector3(0, 0, 0);

        float turn = Input.GetAxis("Mouse Y");
        Debug.Log("turn variable: " + turn);
        turnAmount.Set(-turn, 0, 0);
        turnAmount.x = Mathf.Clamp(turnAmount.x, minimumAngle, maximumAngle);
        transform.Rotate(turnAmount * turnSpeed * Time.deltaTime);

    }
}
