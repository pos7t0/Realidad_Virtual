using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPlant : MonoBehaviour
{

    private string[] phase = new string[] { "Small", "Mid", "Max" };
    private int index=0;

    private Animator plantAnimator;
    private float timer = 0;
    private float timerstop = 0;
    private bool seed = false;

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
        if (seed)
        {
            //si esta tocando alguna particula, se le aumentara al slider y se vera un indicador
            if (isTouch&&index<3)
            {
                canvas.SetActive(true);
                timer += Time.deltaTime;
            }
            else
            {
                canvas.SetActive(false);
            }
            
            //aumentar el tiempo para parar de recibir agua
            timerstop += Time.deltaTime;

            //si pasa del tiempo, se dara el indicativo de que no hay agua colisionando
            if (timerstop>=0.5f)
            {
                isTouch = false;
            }

            //si logra llegar al limite, la planta crecera
            if (water.value>=maxWater)
            {
                Debug.Log("hola");
                plantAnimator.SetTrigger(phase[index]);
                if (index < 3)
                {
                    index++;
                }
                timer = 0;

            }
            
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
            //Debug.Log("Collision: Water");
            //water.value++;
            timerstop = 0;
            isTouch = true;
            //Max();
        }
        else
        {
            isTouch = false;
            //Debug.Log("Collision: Other");
        }
    }

    public void PutSeed()
    {
        seed = true;
    }


}
