using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class MeleeEnemy : Enemy
    {
        public override void Attack()
        {
            // check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= range)
                {
                    Debug.Log("ATTACK");
                    lastAttackTime = Time.time; // update lastAttackTime to the current time
                }
            }
        }
    }

}
