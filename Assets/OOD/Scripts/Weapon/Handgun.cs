using System.Collections;
using System.Collections.Generic;
using OOD.Scripts.Weapon;
using UnityEngine;

public class Handgun : Weapon
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBullet();
        }
    }

    public override void SpawnBullet()
    {
        Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
    }
}
