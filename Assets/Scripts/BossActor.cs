using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BossActor : MonoBehaviour {

    public float bullet_speed = 1.0f;
    public float BossHealth = 100.0f;
    public float attackTime = 1.0f;
    public GameObject missile;
    public GameObject bullet;
    public GameObject key;
    public GameObject winTrigger;
    public Transform bulletSpawnPoint_1;
    public Transform bulletSpawnPoint_2;
    public AudioSource audioSourceRanged;

    private FirstPersonController player;
    private float attackTimer = 0;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        attackTimer -= Time.deltaTime;

        Vector3 Direction = player.transform.position - this.transform.position;
        Direction.y = 0;

        if (Vector3.Distance(player.transform.position, this.transform.position) < 20.0f && attackTimer <= 0.0f)
            shootBullet(); // if the player is within range, fires a bullet

        if (Vector3.Distance(player.transform.position, this.transform.position) < 30.0f) {
            Quaternion rotation = Quaternion.LookRotation(Direction); // rotates the boss to face the player
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 50.0f);
        }

        if (Vector3.Distance(player.transform.position, this.transform.position) < 40.0f && attackTimer <= 0.0f)
            ShootMissile(); // if the attack timer expires, fires a missile

        if (BossHealth <= 0) {
            Instantiate(key, this.transform.position, Quaternion.identity); // creates a key at the boss' position
            Destroy(gameObject); // destroys the boss
            winTrigger.SetActive(true); // allows the player to access the win door
        }
	}

    public void BossTakeDamage(float damage) {
        BossHealth -= damage;
    }

    void shootBullet() {
        GameObject theProjectile = Instantiate(bullet); // creates a new bullet
        audioSourceRanged.Play(); // plays the bullet sound
        theProjectile.transform.position = bulletSpawnPoint_1.transform.position; // shifts the bullet to the spawn point
        Rigidbody rb = theProjectile.GetComponent<Rigidbody>();
        Vector3 direction = player.transform.position - theProjectile.transform.position; // sets the bullet to face the player
        rb.velocity = direction * bullet_speed; // sets the move direction and speed of the bullet
        attackTimer = attackTime; // resets the fire time
        Destroy(theProjectile, 10.0f); // after a certain amount of time, destroys the bullet
    }

    void ShootMissile()
    {
        GameObject theProjectile = Instantiate(missile); // creates a missile
        audioSourceRanged.Play(); // plays the shooting sound
        theProjectile.transform.position = bulletSpawnPoint_2.transform.position; // shifts the missile to the missile spawn point
        attackTimer = attackTime; // resets the fire time
        Destroy(theProjectile, 10.0f); // after a certain amount of time, destroys the missile
    }
}
