using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class RangeEnemy : Enemy
    {
        public GameObject ThrowablePrefab;
        private bool shouldMove;

        public override void Attack()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance>range)
            {
                shouldMove = true;
            }
            else
            {
                shouldMove = false;
                if (lastAttackTime >= attackCooldown)
                {
                    SpawnEnemyThrowable();
                    lastAttackTime = 0f;
                }
            }
            lastAttackTime += Time.deltaTime;
        }

        private void SpawnEnemyThrowable()
        {
            GameObject throwableGameObject = Instantiate(ThrowablePrefab, transform.position, new Quaternion());
            Throwable script = throwableGameObject.AddComponent<Throwable>();
            script.enemyTransform = transform;
            script.playerTransform = player.transform;
        }

        public override void Move()
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            if (shouldMove)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
