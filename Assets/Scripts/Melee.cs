using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    public float damage = 1;
    public float damageFrames = 0;

    // if the weapon comes into contact with an enemy
    void OnCollisionEnter(Collision col) {
        Enemy enemyHealth = col.collider.GetComponent<Enemy>();
        if (enemyHealth != null) {
            enemyHealth.takeDamage(damage);
        }
    }

    private float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time < damageFrames) {
        }
    }
}
