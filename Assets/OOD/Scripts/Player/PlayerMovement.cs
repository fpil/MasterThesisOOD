using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        var movement = new float3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var camera = Camera.main.gameObject;
        var playerObject = gameObject;
    
        Quaternion playerTransformRotation = camera.transform.rotation;
        playerTransformRotation.x = 0;
        playerTransformRotation.z = 0;
    
        // Smooth rotation 
        playerObject.transform.rotation = Quaternion.Lerp(playerObject.transform.rotation, playerTransformRotation, 0.1f);
    
        //Move the character towards its orientation
        float3 rotatedDirection = math.rotate(playerObject.transform.rotation, movement);
        rotatedDirection.y = 0;
        playerObject.transform.position +=
            new Vector3(rotatedDirection.x, rotatedDirection.y, rotatedDirection.z) * 5 * Time.deltaTime;
    }

}
