using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject handGun;
    public GameObject shotGun;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handGun.SetActive(true);
            shotGun.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handGun.SetActive(false);
            shotGun.SetActive(true);
        }
    }
}
