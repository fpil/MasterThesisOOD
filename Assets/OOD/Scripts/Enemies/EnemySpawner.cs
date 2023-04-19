using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeEnemy;
    public GameObject rangeEnemy;
    public GameObject throwable;

    public int numMeleeEnemies;
    public int numRangeEnemies;
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);
    private DayNightController _dayNightController;

    private List<GameObject> throwablePool = new List<GameObject>(); 

    void Start()
    {
        _dayNightController = FindObjectOfType<DayNightController>();
    }

    void Update()
    {
        if (_dayNightController.isNight)
        {
            if (!_dayNightController.enemiesHasSpawned)
            {
                EmptyThrowablePool();
                CreateThrowablePool();
                //Add more enemies based on the number of cycles
                var meleeSpawnEnemies = numMeleeEnemies * _dayNightController.dayNightCycleNumber;
                var rangeSpawnEnemies = numRangeEnemies * _dayNightController.dayNightCycleNumber;
                for (int i = 0; i < meleeSpawnEnemies; i++) {
                    Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), 0, Random.Range(-spawnAreaSize.z, spawnAreaSize.z));
                    Instantiate(meleeEnemy, spawnPosition, Quaternion.identity);
                }
                for (int i = 0; i < rangeSpawnEnemies; i++) {
                    Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), 0, Random.Range(-spawnAreaSize.z, spawnAreaSize.z));
                    Instantiate(rangeEnemy, spawnPosition, Quaternion.identity);
                    // GetThrowableFromPool();
                }
                _dayNightController.enemiesHasSpawned = true;
            }
        }
    }
    
    //Only half the amount of enemies are allowed to shoot because the pool is half the size
    private void CreateThrowablePool()
    {
        for (int i = 0; i < (numRangeEnemies * _dayNightController.dayNightCycleNumber)/2; i++)
        {
            var newThrowable = Instantiate(throwable, Vector3.zero, Quaternion.identity);
            newThrowable.SetActive(false);
            newThrowable.AddComponent<Throwable>();
            throwablePool.Add(newThrowable);
        }
    }
    private void EmptyThrowablePool()
    {
        foreach (var gameObject in throwablePool)
        {
            Destroy(gameObject);
        }
        throwablePool.Clear();
    }
    public GameObject GetThrowableFromPool()
    {
        foreach (var throwable in throwablePool)
        {
            if (!throwable.activeInHierarchy)
            {
                throwable.SetActive(true);
                return throwable;
            }
        }
        return null;
    }
}
