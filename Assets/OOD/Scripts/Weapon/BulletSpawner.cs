using UnityEngine;

namespace OOD.Scripts.Weapon
{
    public class BulletSpawner : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform muzzleTransform;
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SpawnBullet();
            }
        }

        private void SpawnBullet()
        {
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
        }
    }
}
