using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPlant : MonoBehaviour
{
    public enum Directions { SMALL, MID, MAX };
    public Directions tall;

    private Animator plantAnimator;
    private float timer = 0;
    private float timerstop = 0;


    public GameObject canvas;
    private bool isTouch=false;
    public Slider water;
    public float maxWater;
    // Start is called before the first frame update
    void Start()
    {
        plantAnimator = GetComponent<Animator>();
        water.maxValue = maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            canvas.SetActive(true);
            timer += Time.deltaTime;
        }
        else
        {
            canvas.SetActive(false);
        }
        

        timerstop += Time.deltaTime;

        if (timerstop>=0.5f)
        {
            isTouch = false;
        }


        if (canvas.active)
        {
            water.value = timer;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WaterParticle"))
        {
            Debug.Log("Collision: Water");
        }
        else
        {
            Debug.Log("Collision: Other");
        }
    }

    
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("WaterParticle"))
        {
            Debug.Log("Collision: Water");
            //water.value++;
            timerstop = 0;
            isTouch = true;
            //Max();
        }
        else
        {
            isTouch = false;
            Debug.Log("Collision: Other");
        }
    }

    public void Small()
    {
        if (timer > 1)
        {
            if (tall != Directions.SMALL)
            {
                if (tall == Directions.MID)
                {
                    plantAnimator.SetTrigger("Small");
                    timer = 0;
                    tall = Directions.SMALL;

                }
                if (tall == Directions.MAX)
                {
                    plantAnimator.SetTrigger("MaxMin");
                    timer = 0;
                    tall = Directions.SMALL;

                }
            }
        }
    }

    public void Mid()
    {
        if (timer > 1)
        {
            if (tall != Directions.MID)
            {

                if (tall == Directions.SMALL)
                {
                    plantAnimator.SetTrigger("Mid");
                    timer = 0;
                    tall = Directions.MID;

                }
                else if (tall == Directions.MAX)
                {
                    plantAnimator.SetTrigger("Max to Mid");
                    timer = 0;
                    tall = Directions.MID;
                }
            }
        }


    }
    public void Max()
    {
        if (timer > 1)
        {
            if (tall != Directions.MAX)
            {
                if (tall == Directions.SMALL)
                {
                    plantAnimator.SetTrigger("MinMax");
                    tall = Directions.MAX;
                    timer = 0;

                }
                if (tall == Directions.MID)
                {
                    plantAnimator.SetTrigger("Max");
                    tall = Directions.MAX;
                    timer = 0;

                }


            }
        }
    }


}
