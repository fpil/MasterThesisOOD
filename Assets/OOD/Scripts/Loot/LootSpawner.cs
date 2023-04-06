using UnityEngine;

namespace Assets.OOD.Scripts.Loot
{
    public class LootSpawner : MonoBehaviour
    {
        public GameObject shotgunLoot;
        public GameObject machinegunLoot;
        public int spawnRate;
        public int spawnRateItem;
        private int maxSpawnRate = 101;
        public void SpawnLoot(Vector3 spawnPosition)
        {
            int spawnChance = Random.Range(0, 101);
            if (spawnChance<=spawnRate)
            {
                int spawnChanceItem = Random.Range(0, 101);
                if (spawnRateItem <= spawnChanceItem)
                {
                    Instantiate(shotgunLoot, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(machinegunLoot, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
