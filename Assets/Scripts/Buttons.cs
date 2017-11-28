using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public bool play;
    public bool exit;
    public bool mainMenu;

    private Button btn;

	// Use this for initialization
	void Start () {
        // sets the cursor to visible and unlocked (for use with game-to-menu transition)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick() { // when the player clicks on a button:
        if (play) // if the button is marked as 'play' launches the game scene
            SceneManager.LoadScene(1);
        else if (exit) // if the button is marked as 'exit' quits the application
            Application.Quit();
        else if (mainMenu) // if the button is marked 'mainMenu' launches the main menu scene
            SceneManager.LoadScene(0);
    }
}