using System.Collections;
using System.Collections.Generic;
using Assets.OOD.Scripts.Loot;
using Unity.VisualScripting;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public float dayTime;
    public float maxDayTime;
    public bool isNight;
    public bool enemiesHasSpawned;
    public int enemiesLeft;
    public int dayNightCycleNumber;
    public Light directionalLight; 

    void Start()
    {
        dayNightCycleNumber++;
    }

    void Update()
    {
        dayTime += Time.deltaTime;
        if (dayTime>maxDayTime)
        {
            if (!isNight)
            {
                isNight = true;
                //Destroy all loot when new night cycle starts 
                var loots = FindObjectsOfType<LootBehavior>();
                foreach (var loot in loots)
                {
                    Destroy(loot.GameObject().gameObject);
                }
            }
        }

        var enemies = FindObjectsOfType<Enemy>();
        enemiesLeft = enemies.Length;
        if (enemiesLeft == 0 && enemiesHasSpawned)
        {
            dayTime = 0;
            isNight = false;
            enemiesHasSpawned = false;
            dayNightCycleNumber++;
        }

        ChangeLight();
    }

    void ChangeLight()
    {
        if (isNight)
        {
            directionalLight.intensity = 0;
        }
        else
        {
            directionalLight.intensity = 1; 
        }
    }
}
