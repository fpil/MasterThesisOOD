using UnityEngine;

namespace OOD.Scripts.Enemies
{
    public class RangeEnemy : Enemy
    {
        private bool isStandingStill;
        private Vector3 savedPosition;
        public override void Attack()
        {
            if (isStandingStill) {
                transform.position = savedPosition;
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= range)
                {
                    Debug.Log("RangedATTACK");
                    lastAttackTime = Time.time; // update lastAttackTime to the current time
                    // isStandingStill = false; todo this is now correct behavior
                }
            }
            else
            {
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    savedPosition = transform.position;
                    isStandingStill = true;
                }
            }
        }
    }
}
