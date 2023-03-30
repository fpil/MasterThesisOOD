using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OOD.Scripts.Weapon
{
    public class BulletSpawner : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform muzzleTransform;
        private float fireCooldown = 0.5f; // set the fire cooldown time
        private float timeSinceLastShot;

        private void Start()
        {
            muzzleTransform = GameObject.FindWithTag("Muzzle").transform;
        }

        void Update()
        {
            //todo --> modify this so that it uses inheritance
            // if (Input.GetButtonDown("Fire1"))
            // {
            //     SpawnBullet();
            // }
            if (Input.GetButtonDown("Fire1") && timeSinceLastShot > fireCooldown)
            {
                SpawnBulletSpread();
                timeSinceLastShot = 0;
            }
            timeSinceLastShot += Time.deltaTime;
        }

        private void SpawnBullet()
        {
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
        }
        private void SpawnBulletSpread()
        {
            float spread = 2.0f; // set the spread factor
            for (int i = 0; i < 6; i++) // spawn 5 bullets
            {
                Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f); // create random spread rotation
                Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation * spreadRotation); // spawn bullet with spread rotation
            }
        }
    }
}
