using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject handGun;
    public GameObject shotGun;
    public GameObject machineGun;
    public int shotgunAmmo;
    public int machinegunAmmo;

    void Start()
    {
        shotgunAmmo = 50;
        machinegunAmmo = 200;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handGun.SetActive(true);
            shotGun.SetActive(false);
            machineGun.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handGun.SetActive(false);
            shotGun.SetActive(true);
            machineGun.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handGun.SetActive(false);
            shotGun.SetActive(false);
            machineGun.SetActive(true);
        }
    }
}
