using System.Collections;
using UnityEngine;

public class Flickeringlight : MonoBehaviour {

    Light testLight;
    public float minWaitTime;
    public float maxW;

	void Start() { 
     
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
      
}

    IEnumerator Flashing () {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            testLight.enabled = ! testLight.enabled; // after a set time, flickers the light
        }	
	}
}
