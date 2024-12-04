using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    bool didHit = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Plant")) // Replace "Plant" with your target tag
        {
            if (didHit)
            {
                Debug.Log("Collision: Water particle hit plant!");

                WaterPlant plantScript = other.GetComponent<WaterPlant>();

                if (plantScript != null)
                {
                    //plantScript.Small();
                    didHit = false;
                }
                else
                {
                    Debug.LogWarning("No WaterPlant script found on the collided plant!");
                }
            }
        }
        else
        {
            //Debug.Log("Collision: Water particle hit something else.");
        }
    }
}
