using System;
using OOD.Scripts.Weapon;
using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class MeeleEnemy : Enemy
    {
        public int attackDamage;
        private Transform player;
        private GunController _gunController;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            _gunController = GetComponent<GunController>();
        }

        public override void Move() {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public override void Attack() {
            Debug.Log("Attack");
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                Attack();
            }
            
        }
    }
}
