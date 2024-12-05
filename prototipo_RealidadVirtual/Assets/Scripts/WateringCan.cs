using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public ParticleSystem water;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Access the emission module
        var emission = water.emission;

        // Determine tilt angles for X and Z axes
        float tiltForward = Vector3.Angle(transform.right, Vector3.down);  // Check X-axis tilt
        float tiltSideways = Vector3.Angle(transform.forward, Vector3.up); // Check Z-axis tilt

        // Define thresholds for tilting
        bool isTiltingForward = tiltForward > 90 && tiltForward < 150; // Adjust the range as needed
        bool isTiltingSideways = tiltSideways > 90 && tiltSideways < 150; // Adjust the range as needed

        // Enable or disable particle emission based on tilt conditions
        if (isTiltingForward || isTiltingSideways) // Only emit when tilted forward, not sideways
        {
            if (!water.isPlaying)
            {
                water.Play();
                audioSource.Play();
            }
                
            emission.rateOverTime = 10f; // Set particles per second
        }
        else
        {
            audioSource.Stop();
            water.Stop();
            emission.rateOverTime = 0f; // Stop emitting
        }
    }
}
