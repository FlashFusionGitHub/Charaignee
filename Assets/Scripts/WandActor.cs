using UnityEngine;
using InControl;

public class WandActor : MonoBehaviour {

    public float swingSpeed = 1;
    public float damage = 50;

    public float swingTime = 1;
    private float timeRemaining;

    private float xRotation;
    private float yRotation;
    private float zRotation;
    private bool attacking;

//    private ItemPickUp item;
    private InputDevice gamePad;

    // Use this for initialization
    void Start() {
        gamePad = InputManager.ActiveDevice;

        xRotation = transform.rotation.x;
        yRotation = transform.rotation.y;
        zRotation = transform.rotation.z;
        attacking = false;
        timeRemaining = swingTime;
    }
	
	// Update is called once per frame
	void Update () {

        // TODO attack animation. Swings the wand, and any enemy in the way takes damage
        if (Input.GetMouseButtonDown(0))
            attacking = true;
        if (attacking == true) {
            if (timeRemaining > 0)
            {
                transform.Rotate(0, 0, -swingSpeed * Time.deltaTime);
                timeRemaining -= 1 * Time.deltaTime;
            } else attacking = false;
        }
        if (attacking == false)
        {
            if (timeRemaining == swingTime)
            {
                transform.Rotate(0, 0, swingSpeed * Time.deltaTime);
                timeRemaining += 1 * Time.deltaTime;
            }
        }

        // TODO spinning animation when player presses 'R'

    }
}
