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

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player") { // if the player is withing range of the gate, opens the gate
            gate_animator.SetBool("isOpen", true);
            gateCollider.enabled = false;
        }
    }
}
