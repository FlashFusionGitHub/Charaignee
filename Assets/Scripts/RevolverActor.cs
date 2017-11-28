using UnityEngine;
using InControl;

public class RevolverActor : MonoBehaviour {
    public float damage = 50.0f;
    public float range = 150.0f;
    public float shot_time = 1;
    public Camera ray_cast_point;
    public Agent agent;
    public GameObject enemy_impact_effect;
    public GameObject impact_effect;
    public ParticleSystem muzzle_flash;
    public AudioSource audioSourceShoot;
    public AudioSource audioSourceReload;

    private float shot_timer = 0;
    private InputDevice gamePad;
    private ItemPickUp item;
    
	// Use this for initialization
	void Start () {
        item = FindObjectOfType<ItemPickUp>();
        agent = FindObjectOfType<Agent>();
        gamePad = InputManager.ActiveDevice;
    }
	
	// Update is called once per frame
	void Update () {
	    shot_timer -= Time.deltaTime;
        
        if(Input.GetMouseButtonDown(0) && shot_timer <= 0.0f && item.canFire == true) { // when the player shoots, and they can shoot, 
            muzzle_flash.Play(); // plays a muzzle flash effect
            item.Shoot(); // updates all the gun-related stats for the player
            Shoot(); // fires the gun
            audioSourceShoot.Play(); // plays the gunshot sound
            shot_timer = shot_time; // resets the time-to-shoot timer
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            item.canFire = false; // stops the player from firing
            item.reloadGun(); // updates the reload-related stats
            GetComponent<Animator>().Play("Reload", 0); // plays the reload animation
            audioSourceReload.Play(); // plays the relaoding sound
        }

#if UNITY_PS4
        if(gamePad.RightTrigger.WasPressed && shot_timer <= 0.0f && item.canFire == true) {
            muzzle_flash.Play(); // plays a muzzle flash effect
            item.Shoot(); // updates all the gun-related stats for the player
            Shoot(); // fires the gun
            audioSourceShoot.Play(); // plays the gunshot sound
            shot_timer = shot_time; // resets the time-to-shoot timer
        }
        if (gamePad.Action3.WasPressed) {
            item.canFire = false; // stops the player from firing
            item.reloadGun(); // updates the reload-related stats
            GetComponent<Animator>().Play("Reload", 0); // plays the reload animation
            audioSourceReload.Play(); // plays the relaoding sound
        }
#endif
    }

    void Shoot() {
        GetComponent<Animator>().Play("Shoot",0);
        RaycastHit hit;
        GameObject impact_object;

        if (Physics.Raycast(ray_cast_point.transform.position, ray_cast_point.transform.forward, out hit, range)) {
            if(hit.transform.tag == "Enemy") {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal)); // spawns a hit effect
                hit.transform.gameObject.GetComponent<Agent>().agentTakeDamage(damage); // calls the damage function for the enemy

            } else if (hit.transform.tag == "RangedEnemy") {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal)); // spawns a hit effect
                hit.transform.gameObject.GetComponent<RangedAgent>().agentTakeDamage(damage); // calls the damage function for the enemy

            } else if (hit.transform.tag == "Boss") {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal)); // spawns a hit effect
                hit.transform.gameObject.GetComponent<BossActor>().BossTakeDamage(damage); // calls the damage function for the boss

            } else if (hit.transform.tag == "Wall") {
                impact_object = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal)); // spawns a hit effect
                hit.transform.gameObject.GetComponent<WallActor>().wallTakeDamage(damage); // calls the damage function for the wall
            }
            impact_object = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impact_object, 1.0f);
        }
    }
}