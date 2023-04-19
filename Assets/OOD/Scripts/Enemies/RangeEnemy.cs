using UnityEngine;
using UnityEngine.Pool;

namespace OOD.Scripts.Enemies
{
    public class RangeEnemy : Enemy
    {
        public GameObject ThrowablePrefab;
        private EnemySpawner enemySpawner;
        public override void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            lastAttackTime = Time.time; // initialize lastAttackTime to the current time
            enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>(); 
        }

        public override void Attack()
        {
            lastAttackTime += Time.deltaTime;
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance<range)
            {
                // shouldMove = true;
                if (lastAttackTime >= attackCooldown)
                {
                    // SpawnEnemyThrowable();
                    var throwableFromPool = enemySpawner.GetThrowableFromPool();
                    if (throwableFromPool != null)
                    {
                        Throwable script = throwableFromPool.GetComponent<Throwable>();
                        // script.enemyTransform = transform;
                        // script.playerTransform = player.transform;

                        if (script != null)
                        {
                            script.startTime = Time.time;
                            script.startPos = transform.position;
                            script.targetPos = player.position;
                            script.distance = Vector3.Distance(script.startPos, script.targetPos);

                            lastAttackTime = 0f;
                        }
                    }
                }
            }
        }

        private void SpawnEnemyThrowable()
        {
            GameObject throwableGameObject = Instantiate(ThrowablePrefab, transform.position, new Quaternion());
            Throwable script = throwableGameObject.AddComponent<Throwable>();
            // script.enemyTransform = transform;
            // script.playerTransform = player.transform;
        }
    }
}
