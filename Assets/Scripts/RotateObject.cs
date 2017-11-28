using UnityEngine;

public class RotateObject : MonoBehaviour {
    //Publics Allow the Rotations to be Seen in the Unity Editor. 
    public float XRot;
    public float YRot;
    public float ZRot;


    // Update is called once per frame
    void Update() {
        transform.Rotate(XRot * Time.deltaTime, YRot * Time.deltaTime, ZRot * Time.deltaTime);
        //Depending on the Rotation Variable changed by the player within the Editor, 
        //this line of code will rotate the Object with the script applied to it.  
    }

}

