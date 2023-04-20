using UnityEngine;
using UnityEngine.Pool;

namespace OOD.Scripts.Enemies
{
    public class RangeEnemy : Enemy
    {
        private ThrowablePool throwablePool;
        public override void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            lastAttackTime = Time.time; // initialize lastAttackTime to the current time
            throwablePool = GameObject.Find("Spawner").GetComponent<ThrowablePool>(); 
        }

        public override void Attack()
        {
            lastAttackTime += Time.deltaTime;
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance<range)
            {
                if (lastAttackTime >= attackCooldown)
                {
                    var throwableFromPool = throwablePool.GetThrowableFromPool();
                    if (throwableFromPool != null)
                    {
                        Throwable script = throwableFromPool.GetComponent<Throwable>();

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
    }
}
