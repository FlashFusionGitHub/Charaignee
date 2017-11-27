using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

    public GameObject boss;
    public GameObject bossDoor;
    public GameObject player;
    public AudioClip levelMusic;
    public AudioClip bossMusic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boss.GetComponent<BossActor>().enabled = true;
            bossDoor.SetActive(true);
            gameObject.SetActive(false);
            AudioSource audioSource = player.GetComponent<AudioSource>();
            audioSource.Stop();
            audioSource.clip = bossMusic;
            audioSource.Play();
        }
    }
}
