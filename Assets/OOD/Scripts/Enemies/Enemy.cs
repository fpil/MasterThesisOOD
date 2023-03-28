using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public Transform player;
    public float lastAttackTime;
    public int damage;
    public float attackCooldown;
    public float range;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = Time.time; // initialize lastAttackTime to the current time
    }

    public virtual void Move()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);

        Separate();
    }
    public void Separate()
    {
        // Separation behavior
        float separationRadius = 1f;
        float separationForce = 1f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, separationRadius);
        foreach (Collider collider in colliders) {
            if (collider.gameObject.CompareTag("MeleeEnemy") && collider.gameObject != gameObject) { //Todo --> change the default tag when more enemies are added
                Vector3 separationDirection = (transform.position - collider.transform.position).normalized;
                separationDirection.y = 0f;
                transform.position += separationDirection * separationForce * Time.deltaTime;
            }
        }
    }
    public virtual void Attack()
    {
    }
    public void Die()
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
