using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBulletScript : MonoBehaviour {

    private GameObject projectile;
    private HealthBar player_health;

    public float damage = 20.0f;

	// Use this for initialization
	void Start () {
        projectile = GetComponent<GameObject>();
        player_health = FindObjectOfType<HealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Player")
        {
            player_health.TakeDamge(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
