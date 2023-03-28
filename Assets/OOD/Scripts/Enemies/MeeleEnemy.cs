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
            // check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= 1.5f)
                {
                    Debug.Log("ATTACK");
                    lastAttackTime = Time.time; // update lastAttackTime to the current time
                }
            }
        }
    }

}
