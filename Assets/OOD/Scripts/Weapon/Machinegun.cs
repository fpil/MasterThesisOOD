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
            float spread = 2.0f;
            Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f); // create random spread rotation
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation * spreadRotation); // spawn bullet with spread rotation
        }
    }
}
