using System;
using System.Collections;
using System.Collections.Generic;
using Assets.OOD.Scripts.Loot;
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
    public LayerMask obstacleLayer;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = Time.time; // initialize lastAttackTime to the current time
    }

    public virtual void Move()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 2, obstacleLayer))
        {
            Vector3 newDirection = Vector3.zero;
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0.0f;
            newDirection = Vector3.Reflect(direction, hitNormal);
            newDirection = newDirection.normalized;

            // Move in the new direction
            transform.position += newDirection * speed * Time.deltaTime;
        }
        else
        {
            // If there are no obstacles, move towards the player
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    public void Separate()
    {
        // Separation behavior
        float separationRadius = 1f;
        float separationForce = 1f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, separationRadius);
        foreach (Collider collider in colliders) {
            if ((collider.gameObject.CompareTag("MeleeEnemy") || collider.gameObject.CompareTag("RangeEnemy")) && collider.gameObject != gameObject) { //Todo --> change the default tag when more enemies are added
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
        LootSpawner lootSpawner = FindObjectOfType<LootSpawner>();
        lootSpawner.SpawnLoot(gameObject.transform.position);
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
        Attack();
        Separate();
        if (health <= 0)
        {
            Die();
        }
    }
}
