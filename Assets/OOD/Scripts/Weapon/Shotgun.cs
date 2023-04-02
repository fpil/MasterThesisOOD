using System.Collections;
using System.Collections.Generic;
using OOD.Scripts.Weapon;
using UnityEngine;

public class Shotgun : Weapon
{
    private float fireCooldown = 0.5f;
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
        float spread = 2.0f;
        for (int i = 0; i < 6; i++) // spawn 5 bullets
        {
            Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f); // create random spread rotation
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation * spreadRotation); // spawn bullet with spread rotation
        }
    }
}
