using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class WeaponSwitching : MonoBehaviour {

    public int selected_weapon = 0;
    private InputDevice gamePad;

	// Use this for initialization
	void Start () {
        SelectWeapon();
        gamePad = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {

        if (selected_weapon > 2)
            selected_weapon = 0;
        if (selected_weapon < 0)
            selected_weapon = 2;

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

        foreach(Transform weapon in transform)
        { 
            if(i == selected_weapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
