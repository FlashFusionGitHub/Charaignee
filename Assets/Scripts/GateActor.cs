using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActor : MonoBehaviour {

    public Animator gate_animator;
    private Collider gateCollider;

	// Use this for initialization
	void Start () {
        gateCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Player")
        {
            gate_animator.SetBool("isOpen", true);
            gateCollider.enabled = false;
        }
    }
}
