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

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            player_health.TakeDamge(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
