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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick() {
        if (play)
            SceneManager.LoadScene(1);
        else if (exit)
            Application.Quit();
        else if (mainMenu)
            SceneManager.LoadScene(0);
    }
}
