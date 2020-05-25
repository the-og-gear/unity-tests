using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float initialHealth = 10.0f;
    private float currentHealth;

    void Start()
    {
        currentHealth = initialHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
