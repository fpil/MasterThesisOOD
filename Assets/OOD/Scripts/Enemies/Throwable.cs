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
        currentPos.y = Mathf.Lerp(startPos.y, targetPos.y, missingDistance) + height * Mathf.Sin(missingDistance * Mathf.PI);

        transform.position = currentPos;
        
        //todo --> fix the height parameters 
        if (transform.position.y<0)
        {
            Destroy(gameObject);
        }
    }
}
