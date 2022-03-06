using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public float currentHealth;

    public HealthBar healthbar;
    private void Start()
    {
        currentHealth = hitPoints;
        healthbar.SetMaxHealth(hitPoints); 
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

}
