using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeEnemy;
    public GameObject rangeEnemy;

    public int numMeleeEnemies;
    public int numRangeEnemies;
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numMeleeEnemies; i++) {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), 0, Random.Range(-spawnAreaSize.z, spawnAreaSize.z));
            Instantiate(meleeEnemy, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numRangeEnemies; i++) {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), 0, Random.Range(-spawnAreaSize.z, spawnAreaSize.z));
            Instantiate(rangeEnemy, spawnPosition, Quaternion.identity);
        }
    }
}
