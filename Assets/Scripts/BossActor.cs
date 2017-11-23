using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class BossActor : MonoBehaviour {

    public Transform bulletSpawnPoint_1;
    public Transform bulletSpawnPoint_2;

    public GameObject missile;
    public GameObject bullet;

    public GameObject key;

    public float bullet_speed = 1.0f;

    public float BossHealth = 100.0f;

    private FirstPersonController player;

    private float attackTimer = 0;

    public float attackTime = 1.0f;

    public AudioSource audioSourceRanged;


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
            shootBullet();

        if (Vector3.Distance(player.transform.position, this.transform.position) < 30.0f) {
            Quaternion rotation = Quaternion.LookRotation(Direction);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 50.0f);
        }


        if (Vector3.Distance(player.transform.position, this.transform.position) < 40.0f && attackTimer <= 0.0f)
            ShootMissile();

        if (BossHealth <= 0)
        {
            Instantiate(key, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
           // SceneManager.LoadScene(3);
        }
	}

    public void BossTakeDamage(float damage) {
        BossHealth -= damage;
    }

    void shootBullet() {
        GameObject theProjectile = Instantiate(bullet);

        audioSourceRanged.Play();

        theProjectile.transform.position = bulletSpawnPoint_1.transform.position;

        Rigidbody rb = theProjectile.GetComponent<Rigidbody>();

        Vector3 direction = player.transform.position - theProjectile.transform.position;

        rb.velocity = direction * bullet_speed;

        attackTimer = attackTime;

        Destroy(theProjectile, 10.0f);
    }

    void ShootMissile()
    {
        GameObject theProjectile = Instantiate(missile);

        audioSourceRanged.Play();

        theProjectile.transform.position = bulletSpawnPoint_2.transform.position;

        attackTimer = attackTime;

        Destroy(theProjectile, 10.0f);
    }
}
