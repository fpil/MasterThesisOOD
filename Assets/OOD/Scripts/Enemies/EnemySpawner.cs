using OOD.Scripts.Enemies;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeEnemy;
    public GameObject rangeEnemy;
    public GameObject throwable;

    public int numMeleeEnemies;
    public int numRangeEnemies;
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);
    private DayNightController _dayNightController;
    private ThrowablePool throwablePool;

    void Start()
    {
        _dayNightController = FindObjectOfType<DayNightController>();
        throwablePool = gameObject.AddComponent<ThrowablePool>();
    }

    void Update()
    {
        if (_dayNightController.isNight)
        {
            if (!_dayNightController.enemiesHasSpawned)
            {
                //Create the throwablePool
                throwablePool.EmptyThrowableToPools();
                throwablePool.CreatePool(throwable,(numRangeEnemies * _dayNightController.dayNightCycleNumber)/4);

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
}
