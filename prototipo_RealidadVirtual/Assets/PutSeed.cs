using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutSeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plant"))
        {
            other.GetComponent<WaterPlant>().PutSeed();
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
