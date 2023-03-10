using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;
    public Slider healthBar;

    public int moneyOnDeath = 10;

    void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;

        LevelManager.instance.activeEnemies.Add(this);

        AudioManager.instance.PlaySFX(7);
    }
    
    void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if(totalHealth <= 0)
        {
            totalHealth = 0;
            Destroy(gameObject);

            AudioManager.instance.PlaySFX(5);

            MoneyManager.instance.GiveMoney(moneyOnDeath);
            LevelManager.instance.activeEnemies.Remove(this);
        }

        healthBar.value = totalHealth;

        healthBar.gameObject.SetActive(true);
    }
}
