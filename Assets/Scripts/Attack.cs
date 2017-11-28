using UnityEngine;

public class Attack : MonoBehaviour {

    
    public float rotationSpeed = 180;
    public float attackDuration = 0.5f;
    public float damage = 500;
    public float range = 2000;

    public Transform RayCastOrigin;

    private float attackTimer = 0;
    private bool attacking = false;
    private float xRotation;
    private float yRotation;
    private float zRotation;

    private AudioSource audioSource;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (attacking)
    //    {
    //        if (other.tag == "Enemy")
    //        {
    //            Debug.Log("hit");
    //            other.GetComponent<Agent>().agentTakeDamage(damage);
    //        }
    //    }
    //    else if (other.tag == "Wall")
    //    {
    //        other.GetComponent<Agent>().agentTakeDamage(damage);
    //    }
    //}

    // Use this for initialization
    void Start ()
    {
        xRotation = transform.rotation.x;
        yRotation = transform.rotation.y;
        zRotation = transform.rotation.z;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //if left mouse button is pressed and not currently attacking, state is set to attacking
		if (Input.GetButtonDown("Fire1") && !attacking)
        {
            audioSource.Play();
            attacking = true;
            HitEnemy();
        }
        //while attacking
        if (attacking)
        {

            //updates timer whilst attacking
            attackTimer += Time.deltaTime;
            //rotates sword like an attack animation
            gameObject.transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
        }

        //if attacking timer exceeds duration
        if (attackTimer >= attackDuration)
        {
            //no longer in attacking state
            attacking = false;
            //timer reset
            attackTimer = 0;
            //resets rotation
            transform.localRotation = Quaternion.identity;
            //transform.Rotate(Vector3.up * -90);
            transform.Rotate(0,-120,-10);
        }
	}

    void HitEnemy()
    {
        RaycastHit hit;

        if (Physics.Raycast(RayCastOrigin.transform.position, RayCastOrigin.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
                hit.transform.gameObject.GetComponent<Agent>().agentTakeDamage(damage);
            if (hit.transform.tag == "RangedEnemy")
                hit.transform.gameObject.GetComponent<RangedAgent>().agentTakeDamage(damage);
            if (hit.transform.tag == "Boss")
                hit.transform.gameObject.GetComponent<BossActor>().BossTakeDamage(damage);
            if (hit.transform.tag == "Wall")
                hit.transform.gameObject.GetComponent<WallActor>().wallTakeDamage(damage);
        }
    }
}
