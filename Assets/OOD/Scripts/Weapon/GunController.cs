using System.Collections;
using System.Collections.Generic;
using OOD.Scripts.Enemies;
using UnityEngine;

namespace OOD.Scripts.Weapon
{
    public class GunController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform muzzleTransform;
        public float bulletRange = 100f;
        public float bulletSpeed = 1.9f;
        private Vector3 bulletDirection;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
            Vector3 bulletVelocity = muzzleTransform.forward * bulletRange;
            StartCoroutine(UpdateBulletPosition(bullet, bulletVelocity));

            // Destroy the bullet after 2 seconds
            StartCoroutine(DestroyBulletAfterDelay(bullet, 2));
        }

        IEnumerator UpdateBulletPosition(GameObject bullet, Vector3 velocity)
        {
            while (bullet != null)
            {
                RaycastHit hit;
                if (Physics.Raycast(bullet.transform.position, velocity.normalized, out hit, velocity.magnitude * Time.deltaTime))
                {
                    if (hit.collider.gameObject.tag == "MeeleEnemy")
                    {
                        var meeleEnemy = hit.collider.gameObject.GetComponent<MeeleEnemy>();
                        meeleEnemy.health -= 5; 
                        Debug.Log("Decrease");
                    }
                    Destroy(bullet);
                    yield break;
                }
                bullet.transform.position += bullet.transform.forward * bulletRange * bulletSpeed  * Time.deltaTime;

                yield return null;
            }
        }

        IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(bullet);
        }
    }
}
