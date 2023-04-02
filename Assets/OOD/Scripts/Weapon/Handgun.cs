using System.Collections;
using System.Collections.Generic;
using OOD.Scripts.Weapon;
using UnityEngine;

public class Handgun : Weapon
{
    public float fireCooldown = 0.2f;
    private float timeSinceLastShot;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeSinceLastShot > fireCooldown)
        {
            SpawnBullet();
            timeSinceLastShot = 0;
        }
        timeSinceLastShot += Time.deltaTime;
    }

    public override void SpawnBullet()
    {
        Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
    }
}
