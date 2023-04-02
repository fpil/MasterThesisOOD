using System.Collections;
using System.Collections.Generic;
using OOD.Scripts.Weapon;
using UnityEngine;

public class Handgun : Weapon
{
    private float fireCooldown = 0.3f;
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
