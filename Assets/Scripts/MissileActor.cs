using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MissileActor : MonoBehaviour {

    private FirstPersonController player;
    private HealthBar player_health;

    public float damage = 10.0f;

    void Start() {
        player = FindObjectOfType<FirstPersonController>();
        player_health = FindObjectOfType<HealthBar>();
    }

	// Update is called once per frame
	void Update () {
        Vector3 direction = player.transform.position - this.transform.position; // moves the player towards the aimed position
        this.transform.up = direction;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction * 2.0f;
	}

    void OnTriggerEnter(Collider hit) {
        if (hit.tag == "Player") {
            player_health.TakeDamge(damage); // damages the player
            Destroy(gameObject); // destroys the bullet
        }

        Destroy(gameObject);
    }
}