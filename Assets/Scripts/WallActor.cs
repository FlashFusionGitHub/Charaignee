using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActor : MonoBehaviour {

    private float Health = 50.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void wallTakeDamage(float playerAttack)
    {
        Health -= playerAttack;
    }
}
