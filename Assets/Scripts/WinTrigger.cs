using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {

    private bool endGame;

	// Use this for initialization
	void Start () {
        endGame = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endGame = true;
        }
    }

    public bool EndGame()
    {
        return endGame;
    }
}
