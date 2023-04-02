using UnityEngine;

namespace OOD.Scripts.Weapon
{
    public class Machinegun : Weapon
    {
        private float fireCooldown = 0.1f;
        private float timeSinceLastShot;
       
        void Update()
        {
            if (Input.GetButton("Fire1") && timeSinceLastShot > fireCooldown)
            {
                SpawnBullet();
                timeSinceLastShot = 0;
            }
            timeSinceLastShot += Time.deltaTime;
        }
        
        public override void SpawnBullet()
        {
            //todo --> figure out why the first shot is a shotgun shotr
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
        }
    }
}
