using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class ItemPickUp : MonoBehaviour
{
    public Text KeysCollectedText;
    public Text AmmoText;
    public Text PickUpText;
    public Text AmmoInGunText;

    private int ammoCount;
    private int ammoInGun;
    private int numberOfBulletsUsed;
    private int numberOfKeys = 1;
    private int maxAmmo = 30;
    private InputDevice gamePad;
    private WeaponSwitching weapon_switching;

    public bool canFire;
    bool Destroyed;

    void Start()
    {
        weapon_switching = FindObjectOfType<WeaponSwitching>();

        gamePad = InputManager.ActiveDevice;
        AmmoText.text = "Ammo: " + ammoCount;
        AmmoInGunText.text = "0";
        numberOfBulletsUsed = 0;
        KeysCollectedText.text = "Keys Collected: 0";
        canFire = false;
        Destroyed = false;
    }

    void Update()
    {
        if (Destroyed == true)
        {
            numberOfKeys += 1;
            Destroyed = false;
        }

        if (ammoInGun > 0)
            canFire = true;
        else
            canFire = false;
    }


    void OnTriggerStay(Collider hit)
    {
        if (hit.tag == "Key")
        {
            PickUpText.text = "Press 'E' to collect key";
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(hit.gameObject);
                Destroyed = true;
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys;
                PickUpText.text = "";
            }

#if UNITY_PS4
            PickUpText.text = "Press 'Circle' to collect key";
            if (gamePad.Action2)
            {
                Destroy(hit.gameObject);
                Destroyed = true;
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys;
                PickUpText.text = "";
            }
#endif
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Ammo")
        {
            if (ammoCount < maxAmmo)
            {
                ammoCount += 6;

                if (ammoCount > maxAmmo)
                    ammoCount = maxAmmo;

                AmmoText.text = "Ammo: " + ammoCount;
                Destroy(hit.gameObject);
            }
            else
                return;
        }

        if (hit.tag == "Revolver")
        {
            Destroy(hit.gameObject);
            weapon_switching.setRevolverState(true);
        }

        if (hit.tag == "MeleeWeapon")
        {
            Destroy(hit.gameObject);
            weapon_switching.setMeleeWeaponState(true);
        }
    }

    void OnTriggerExit(Collider hit)
    {
        PickUpText.text = "";
    }

    public void Shoot()
    {
        if (ammoInGun > 0)
        {
            ammoInGun--;
            numberOfBulletsUsed++;
            UpdateAmmoStatusText();
        }
    }

    public void reloadGun()
    {
        if(ammoCount > 0 && ammoInGun < 6)
        {
            if (ammoCount <= numberOfBulletsUsed)
                ammoInGun += ammoCount;
            else
                ammoInGun = 6;

            if (numberOfBulletsUsed <= 0)
                ammoCount -= 6;
            else
                ammoCount -= numberOfBulletsUsed;

            if (ammoCount < 0)
                ammoCount = 0;

            UpdateAmmoStatusText();

            numberOfBulletsUsed = 0;
        }
    }

    void UpdateAmmoStatusText()
    {
        AmmoText.text = "Ammo: " + ammoCount.ToString();
        AmmoInGunText.text = ammoInGun.ToString();
    }
}
