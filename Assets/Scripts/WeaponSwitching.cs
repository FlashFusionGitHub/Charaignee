using System.Collections;
using System.Collections.Generic;
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
	void Update ()
    {
        if (selected_weapon > 1)
            selected_weapon = 0;
        if (selected_weapon < 0)
            selected_weapon = 1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selected_weapon++;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selected_weapon--;

#if UNITY_PS4
        if(gamePad.DPadRight.WasPressed)
            selected_weapon++;
        if(gamePad.DPadLeft.WasPressed)
            selected_weapon--;
#endif

        SelectWeapon();
	}

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (haveRevoler == true && haveMeleeWeapon == true)
            {
                if (i == selected_weapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
                i++;
            }
        }     
    }

    public void setRevolverState(bool value)
    {
        revolver.SetActive(value);
        haveRevoler = value;
    }

    public void setMeleeWeaponState(bool value)
    {
        MeleeWeapon.SetActive(value);
        haveMeleeWeapon = value;
    }
}
