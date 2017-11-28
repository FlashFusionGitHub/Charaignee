using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public  float health = 100;
    public Image currentHealthbar;
    public Text ratioText;
    public AudioSource audioSourceHealth;

    private float max_health = 100;
    private FirstPersonController player;
    
    void Start() {
        player = FindObjectOfType<FirstPersonController>();
    }

    void OnTriggerEnter(Collider hit) {
        if(hit.tag == "Health" && health < max_health) {
            HealDamage(20); // heals for 20 health
            hit.gameObject.SetActive(false); // destroys the healing item
        }
    }

    void UpdateHealthBar() {
        float ratio = health / max_health; // makes a ratio of current health to maximum health

        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1); // changes the health bar size based on the ratio
        ratioText.text = (ratio * 100).ToString() + '%'; // displays the player health numerically
    }

    public void TakeDamge(float damage) {
        health -= damage;

        if (health <= 0) { // when the player dies, goes the the lose screen
            SceneManager.LoadScene(2);
        }

        UpdateHealthBar();
    }

    private void HealDamage(float heal) {
        audioSourceHealth.Play(); // plays the heal sound
        health += heal; // adds the heal amount to the health

        if (health > max_health) // if the healing goes over the maximum bed, sets it to 100
            health = max_health;

        UpdateHealthBar();
    }
}