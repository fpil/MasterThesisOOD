using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    public virtual void Move()
    {
    }
    public virtual void Separate()
    {
        // Separation behavior
        float separationRadius = 1f;
        float separationForce = 1f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, separationRadius);
        foreach (Collider collider in colliders) {
            if (collider.gameObject.CompareTag("MeeleEnemy") && collider.gameObject != gameObject) { //Todo --> change the default tag when more enemies are added
                Vector3 separationDirection = (transform.position - collider.transform.position).normalized;
                separationDirection.y = 0f;
                transform.position += separationDirection * separationForce * Time.deltaTime;
            }
        }
    }
    public virtual void Attack()
    {
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
        Attack();
        if (health <= 0)
        {
            Die();
        }
    }
}
