using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // [SerializeField] AudioSource audiosource;

    bool isDead = false;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        audioSource.Stop();
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
