using UnityEngine;

namespace Assets.OOD.Scripts.Loot
{
    public class LootBehavior : MonoBehaviour
    {
        public float rotationSpeed = 20f;
        private WeaponController _weaponController;

        void Start()
        {
            _weaponController = FindObjectOfType<WeaponController>();
        }

        void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            CheckCollision();
        }

        void CheckCollision()
        {
            float separationRadius = 0.5f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, separationRadius);
            foreach (Collider collider in colliders) {
                if (collider.gameObject.CompareTag("Player")) {
                    if (gameObject.tag == "ShotgunLoot")
                    {
                        _weaponController.shotgunAmmo += Random.Range(10, 30);
                    }
                    else if (gameObject.tag == "MachinegunLoot")
                    {
                        _weaponController.machinegunAmmo += Random.Range(30, 100);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
