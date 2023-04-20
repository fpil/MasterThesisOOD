using System;
using OOD.Scripts.Enemies;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float speed = 5.0f;
    public float height = 2.0f;

    public float startTime;
    public float distance;
    public Vector3 startPos;
    public Vector3 targetPos;
    private float terrainHeight = -1.52f;

    private ThrowablePool throwablePool;

    // Start is called before the first frame update
    void Start()
    {
        throwablePool = GameObject.Find("Spawner").GetComponent<ThrowablePool>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceSoFar = (Time.time - startTime) * speed;
        float missingDistance = distanceSoFar / distance;

        Vector3 currentPos = Vector3.Lerp(startPos, targetPos, missingDistance);
        float parabolaHeight = height * Mathf.Sin(missingDistance * Mathf.PI);
        currentPos.y = Mathf.Max(Mathf.Lerp(startPos.y, targetPos.y, missingDistance) + parabolaHeight, terrainHeight);

        transform.position = currentPos;

        if (transform.position.y <= targetPos.y)
        {
            gameObject.SetActive(false);
            throwablePool.ReturnThrowableToPool(gameObject);
        }
        Collision();
    }

    void Collision()
    {
        float radius = .2f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders) {
            if ((collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Obstacle")) && collider.gameObject != gameObject) { 
               gameObject.SetActive(false);
               throwablePool.ReturnThrowableToPool(gameObject);
            }
        }
    }
}
