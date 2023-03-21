using System;
using OOD.Scripts.Weapon;
using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class MeeleEnemy : Enemy
    {
        public int attackDamage;
        private Transform player;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void Move() {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            
            Separate();
            
            //Todo --> move this into separate method
            // Raycast collision checking
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, 0.5f)) {
                if (hit.collider.gameObject.CompareTag("Player")) {
                    Attack();
                }
            }
        }

        public override void Attack() {
            Debug.Log("Attack");
        }
        
    }
}
