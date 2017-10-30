using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float health = 1;
    // Use this for initialization

    public void takeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            gameObject.SetActive(false);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
