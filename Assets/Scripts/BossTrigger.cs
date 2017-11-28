using UnityEngine;

public class BossTrigger : MonoBehaviour {

    public GameObject boss;
    public GameObject bossDoor;
    public GameObject player;
    public AudioClip levelMusic;
    public AudioClip bossMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Boss Triggered");
            boss.GetComponent<BossActor>().enabled = true; // turns on the boss
            bossDoor.SetActive(true); // activates the boss door
            gameObject.SetActive(false);
            AudioSource audioSource = player.GetComponent<AudioSource>(); // instantiates the song
            audioSource.Stop(); // stops the music playing
            audioSource.clip = bossMusic; // shifts music to boss
            audioSource.Play(); // plays the music
        }
    }
}
