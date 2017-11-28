using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
    public Image currentHealthbar;
    public Text ratioText;

    public  float health = 100;

    private float max_health = 100;
    private float enemyAttackTimer = 0;
    private float enemyAttackTime = 5;
    private FirstPersonController player;

    public AudioSource audioSourceHealth;


    void Start() {
        player = FindObjectOfType<FirstPersonController>();
    }

    void OnTriggerEnter(Collider hit) {
        //added if health less than max health condition and disables gameobject on use - brodie
        if(hit.tag == "Health" && health < max_health) {
            HealDamage(20);
            hit.gameObject.SetActive(false);

        }
    }

    void UpdateHealthBar() {
        float ratio = health / max_health;

        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    public void TakeDamge(float damage) {
        health -= damage;

        if (health <= 0) {
            player.transform.position = new Vector3(0, 1.5f, 0);
            health = max_health;
            SceneManager.LoadScene(2);
        }

        UpdateHealthBar();
    }

    private void HealDamage(float heal) {
        audioSourceHealth.Play();
        health += heal;

        if (health > 100)
            health = max_health;

        UpdateHealthBar();
    }
}
