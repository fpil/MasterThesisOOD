using System;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;
    public float speed = 5.0f;
    public float height = 2.0f;

    private float startTime;
    private float distance;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float terrainHeight = -1.52f;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        startPos = enemyTransform.position;
        targetPos = playerTransform.position;
        distance = Vector3.Distance(startPos, targetPos);
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
            Destroy(gameObject);
        }
        Collision();
    }

    void Collision()
    {
        float radius = .2f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders) {
            if (collider.gameObject.CompareTag("Player") && collider.gameObject != gameObject) { 
               Debug.Log("Collision with player");
               Destroy(gameObject);
            }
        }
    }
}
