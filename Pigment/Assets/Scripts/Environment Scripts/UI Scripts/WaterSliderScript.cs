using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSliderScript : MonoBehaviour
{
    //variable for the slider component
    public Slider waterSlider;

    public GameObject fill;

    public GameObject handle;

    //variable for the max water level
    public float maxWater;

    //variable for customization of how fast the water slider value goes down
    public float waterDecreaseRate = 1;

    private void Start()
    {
        waterSlider = gameObject.GetComponent<Slider>();// grabs slider component
        waterSlider.value = maxWater; //assigns the starting value to maxvalue
        waterSlider.maxValue = maxWater; //sets the maxvalue to the variable
    }

    void Update()
    {
        if(waterSlider.value <= 0)
        {
            fill.SetActive(false);
            handle.SetActive(false);            
        }

        else if (waterSlider.value > 0) //so long as there is water, the water level will decrease
        {
            waterSlider.value -= waterDecreaseRate * Time.deltaTime / 2;

            fill.SetActive(true);
            handle.SetActive(true);
        }       
    }

    public void ResetWater() //this is called when a water bottle hits the cauldron
    {
        waterSlider.value = maxWater;
    }
}
