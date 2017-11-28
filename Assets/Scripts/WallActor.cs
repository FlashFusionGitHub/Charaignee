using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActor : MonoBehaviour {


//the wall actor script is attached to a hidden wall in the game,
//if the player shoots this wall the this gameObject will be destroyed

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
