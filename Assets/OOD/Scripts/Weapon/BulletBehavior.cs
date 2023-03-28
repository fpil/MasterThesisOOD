using OOD.Scripts.Enemies;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletRange;
    public float lifeTime;
    public float maxLifeTime;
    void Update()
    {
        lifeTime += Time.deltaTime;
        UpdateBulletPosition();

        if (lifeTime>=maxLifeTime)
        {
            DestroyBullet();
        }
    }

    private void UpdateBulletPosition()
    {
        Vector3 bulletVelocity = transform.forward*bulletRange;
        // Debug.DrawRay(transform.position, bulletVelocity.normalized*bulletVelocity.magnitude*Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, bulletVelocity.normalized, out hit, bulletVelocity.magnitude * Time.deltaTime))
        {
            if (hit.collider.gameObject.CompareTag("MeleeEnemy") 
                || hit.collider.gameObject.CompareTag("RangeEnemy"))
            {
                var enemy = hit.collider.gameObject.GetComponent<Enemy>();
                enemy.health -= 5; 
            }
            Destroy(gameObject);
        }
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
