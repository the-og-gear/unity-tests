using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20.0f;
    public float life = 5.0f;
    public float damageDealt = 5.0f;

    void Start()
    {
        Invoke("Kill", life);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    { 
        EnemyHealth health = other.gameObject.GetComponent<EnemyHealth>();

        if (health != null)
        {
            health.TakeDamage(damageDealt);
        }
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
