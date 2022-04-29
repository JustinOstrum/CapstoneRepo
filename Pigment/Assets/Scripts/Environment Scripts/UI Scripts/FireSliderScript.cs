using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSliderScript : MonoBehaviour
{
    //variable for the cauldron script
    CauldronScript cauldronScript;

    //variable for the slider component
    public Slider fireSlider;

    //variable for counting down
    public float countdown;

    public GameObject fill;

    public GameObject handle;
    
    //variable for matching the maxvalue of the slider to the brewtime of the cauldron
    public float maxFire;

    private void Awake()
    {
        cauldronScript = GetComponentInParent<CauldronScript>(); //grabs the cauldron script reference    
    }

    private void Start()
    {
        fireSlider = gameObject.GetComponent<Slider>(); // grabs the slider component
        fireSlider.maxValue = cauldronScript.brewTime; //assigns the maxvalue of the slider to brewtime from cauldron script
    }

    void Update()
    {
        fireSlider.value = cauldronScript.brewTimeCounter; //makes sure that the slider moves at the same rate that the brewtimer is calculating

        if (cauldronScript.hasFuel)
        {
            fill.SetActive(true);
            handle.SetActive(true);
        }

        else
        {
            fill.SetActive(false);
            handle.SetActive(false);
        }
    }
}
