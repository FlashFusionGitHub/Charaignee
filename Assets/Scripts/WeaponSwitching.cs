using UnityEngine;
using InControl;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSwitching : MonoBehaviour {

    public int selected_weapon = 0;
    private InputDevice gamePad;
    private FirstPersonController player;
    private bool haveMeleeWeapon;
    private bool haveRevoler;

    public GameObject revolver;
    public GameObject MeleeWeapon;

    // Use this for initialization
    void Start () {
        SelectWeapon();
        gamePad = InputManager.ActiveDevice;
        haveRevoler = false;
        haveMeleeWeapon = false;
        revolver.SetActive(false);
        MeleeWeapon.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        // allows cycling through weaponry
        if (selected_weapon > 1)
            selected_weapon = 0;
        if (selected_weapon < 0)
            selected_weapon = 1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selected_weapon++; // cycles weaponry up

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selected_weapon--; // cycles weaponry down

#if UNITY_PS4
        if(gamePad.DPadRight.WasPressed)
            selected_weapon++;
        if(gamePad.DPadLeft.WasPressed)
            selected_weapon--;
#endif

        SelectWeapon();
	}

    void SelectWeapon() {
        int i = 0;

        foreach (Transform weapon in transform) {
            if (haveRevoler == true && haveMeleeWeapon == true) {
                if (i == selected_weapon)
                    weapon.gameObject.SetActive(true); // activates the selected weapon
                else
                    weapon.gameObject.SetActive(false); // deselects the non-selected weapon
                i++;
            }
        }     
    }

    public void setRevolverState(bool value) {
        revolver.SetActive(value); // activates the revolver
        haveRevoler = value;
    }

    public void setMeleeWeaponState(bool value) {
        MeleeWeapon.SetActive(value); // activates the wand
        haveMeleeWeapon = value;
    }
}