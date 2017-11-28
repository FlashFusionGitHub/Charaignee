using UnityEngine;

public class WinTrigger : MonoBehaviour {

    private bool endGame;

	// Use this for initialization
	void Start () {
        endGame = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            endGame = true; // if the player touches the win door, ends the game
        }
    }

    public bool EndGame() {
        return endGame;
    }
}