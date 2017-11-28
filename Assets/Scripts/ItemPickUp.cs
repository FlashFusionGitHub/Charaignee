using UnityEngine;
using UnityEngine.UI;
using InControl;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemPickUp : MonoBehaviour {
    public Text KeysCollectedText;
    public Text AmmoText;
    public Text PickUpText;
    public Text AmmoInGunText;
    public AudioSource audioSourceAmmo;
    public bool canFire;

    private int ammoCount;
    private int ammoInGun;
    private int numberOfBulletsUsed;
    private int maxAmmo = 30;
    private int numberOfKeys = 0;
    private InputDevice gamePad;
    private WeaponSwitching weapon_switching;
    private FirstPersonController player;

    bool Destroyed;

    void Start() {
        weapon_switching = FindObjectOfType<WeaponSwitching>();

        player = FindObjectOfType<FirstPersonController>();

        gamePad = InputManager.ActiveDevice;
        AmmoText.text = "Ammo: " + ammoCount;
        AmmoInGunText.text = "0";
        numberOfBulletsUsed = 0;
        KeysCollectedText.text = "Keys Collected: 0";
        canFire = false;
        Destroyed = false;
    }

    void Update() {
        // checks if there is ammo in the player's gun. if there is, they can fire, otherwise, they cannot
        if (ammoInGun > 0)
            canFire = true;
        else
            canFire = false;
    }

    void OnTriggerStay(Collider hit) {
        if (hit.tag == "Key") {
            PickUpText.text = "Press 'E' to collect key";
            if (Input.GetKeyDown(KeyCode.E)) { // if the player presses 'E'
                Destroy(hit.gameObject); // destroys the key
                numberOfKeys += 1; // adds a key to the player inventory
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys; // updates the keys collected text
                PickUpText.text = ""; // removes the collect text
            }

#if UNITY_PS4
            PickUpText.text = "Press 'Circle' to collect key";
            if (gamePad.Action2) {
                Destroy(hit.gameObject);
                Destroyed = true;
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys;
                PickUpText.text = "";
            }
#endif
        }
        if (hit.tag == "Door" && numberOfKeys > 0) {
            PickUpText.text = "Press 'E' to open door";
            if (Input.GetKey(KeyCode.E)) {
                numberOfKeys--; // decrements the amount of keys in the player inventory
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys;
                PickUpText.text = ""; // removes the text display
                hit.gameObject.SetActive(false); // removes the door
            }
        }
    }

#if UNITY_PS4
            PickUpText.text = "Press 'Circle' to open door";
            if (gamePad.Action2) {
                Destroy(hit.gameObject);
                Destroyed = true;
                numberOfKeys = numberOfKeys - 1;
                KeysCollectedText.text = "Keys Collected: " + numberOfKeys;
                PickUpText.text = "";
            }
#endif

    void OnTriggerEnter(Collider hit) {
        if (hit.tag == "Ammo") {
            if (ammoCount < maxAmmo) {
                ammoCount += 6;

                if (ammoCount > maxAmmo)
                    ammoCount = maxAmmo;

                AmmoText.text = "Ammo: " + ammoCount;
                audioSourceAmmo.Play();
                Destroy(hit.gameObject);
            }
        }

        if (hit.tag == "Revolver") {
            Destroy(hit.gameObject); // destroys the revolver
            weapon_switching.setRevolverState(true); // adds it to the equipment list
        }

        if (hit.tag == "MeleeWeapon") {
            Destroy(hit.gameObject); // destroys the wand
            weapon_switching.setMeleeWeaponState(true); // adds it to the equipment list
        }
    }

    void OnTriggerExit(Collider hit) { // clears the pickup text when the player is leaves an interactable object
        PickUpText.text = "";
    }

    public void Shoot() {
        if (ammoInGun > 0) {
            ammoInGun--;
            numberOfBulletsUsed++;
            UpdateAmmoStatusText();
        }
    }

    public void reloadGun() {
        if(ammoCount > 0 && ammoInGun < 6) {
            if (ammoCount <= numberOfBulletsUsed) // if the ammo counter is less than the bullets used, adds the remaining ammo to the gun
                ammoInGun += ammoCount;
            else
                ammoInGun = 6; // else sets the ammo in gun to 6
            if (numberOfBulletsUsed <= 0)
                ammoCount -= 6;
            else
                ammoCount -= numberOfBulletsUsed; 
            if (ammoCount < 0) // if ammoCount is less than 0, sets it to 0
                ammoCount = 0;

            UpdateAmmoStatusText(); // updates the ammo text

            numberOfBulletsUsed = 0;
        }
    }

    void UpdateAmmoStatusText() {
        AmmoText.text = "Ammo: " + ammoCount.ToString();
        AmmoInGunText.text = ammoInGun.ToString();
    }
}