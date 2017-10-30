using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHSpin : MonoBehaviour {
    public float spinSpeed = 1;

    private CharacterController controller;
	// Use this for initialization
	void Start () {
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float spin = spinSpeed * Time.deltaTime;
        transform.Rotate(0, 0, spin);
	}
}
