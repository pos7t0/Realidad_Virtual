using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateToPlayer : MonoBehaviour
{
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;

        // Calculate the angle on the Y-axis
        float targetYRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        targetYRotation += 180;

        // Apply the rotation only on the Y-axis
        transform.rotation = Quaternion.Euler(0, targetYRotation, 0);
    }
}
