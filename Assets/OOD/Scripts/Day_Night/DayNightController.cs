using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public float dayTime;
    public float maxDayTime;
    public bool isNight;
    public bool enemiesHasSpawned;
    public int enemiesLeft;
    public int dayNightCycleNumber;

    void Start()
    {
        dayNightCycleNumber++;
    }

    void Update()
    {
        dayTime += Time.deltaTime;
        if (dayTime>maxDayTime)
        {
            isNight = true;
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
    }
}
