using UnityEngine;

public class Attack : MonoBehaviour {

    
    public float rotationSpeed = 180;
    public float attackDuration = 0.5f;
    public float damage = 50;

    private float attackTimer = 0;
    private bool attacking = false;
    private float xRotation;
    private float yRotation;
    private float zRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (attacking)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<Agent>().agentTakeDamage(damage);
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        xRotation = transform.rotation.x;
        yRotation = transform.rotation.y;
        zRotation = transform.rotation.z;
    }
	
	// Update is called once per frame
	void Update () {
        //if left mouse button is pressed and not currently attacking, state is set to attacking
		if (Input.GetButtonDown("Fire1") && !attacking)
        {
            attacking = true;
            Debug.Log("Attacking");
        }
        //while attacking
        if (attacking)
        {

            //hitting an enemy
            

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
            Debug.Log("No longer attacking");
            //resets rotation
            transform.localRotation = Quaternion.identity;
            //transform.Rotate(Vector3.up * -90);
            transform.Rotate(0,-120,-10);
        }
	}



}
