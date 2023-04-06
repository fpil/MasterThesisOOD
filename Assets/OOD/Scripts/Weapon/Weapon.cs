using UnityEngine;

namespace OOD.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform muzzleTransform;
        public WeaponController _weaponController;
        // Start is called before the first frame update
        void Start()
        {
            muzzleTransform = GameObject.FindWithTag("Muzzle").transform;
            _weaponController = FindObjectOfType<WeaponController>();
        }
        
        public virtual void SpawnBullet()
        {
        }
        
    }
}
