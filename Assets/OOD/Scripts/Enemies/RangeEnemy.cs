using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class RangeEnemy : Enemy
    {
        public GameObject ThrowablePrefab;

        public override void Attack()
        {
            lastAttackTime += Time.deltaTime;
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance<range)
            {
                // shouldMove = true;
                if (lastAttackTime >= attackCooldown)
                {
                    SpawnEnemyThrowable();
                    lastAttackTime = 0f;
                }
            }
        }

        private void SpawnEnemyThrowable()
        {
            GameObject throwableGameObject = Instantiate(ThrowablePrefab, transform.position, new Quaternion());
            Throwable script = throwableGameObject.AddComponent<Throwable>();
            script.enemyTransform = transform;
            script.playerTransform = player.transform;
        }
    }
}
