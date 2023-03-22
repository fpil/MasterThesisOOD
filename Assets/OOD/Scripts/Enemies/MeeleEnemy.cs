using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class MeeleEnemy : Enemy
    {
        public int attackDamage;
        private Transform player;
        private float attackCooldown = 1f;
        private float lastAttackTime;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            lastAttackTime = Time.time; // initialize lastAttackTime to the current time
        }

        public override void Move()
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            Separate();
            
        }

        public override void Attack()
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // Raycast collision checking
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, 1.0f))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        //todo --> add attack behavior
                        Debug.Log("Attack");
                        lastAttackTime = Time.time; // update lastAttackTime to the current time
                    }
                }
            }
        }
    }

}
