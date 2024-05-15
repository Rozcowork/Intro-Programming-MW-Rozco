using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Use the Unity UI Engine

public class HealthBar : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Slider slider; //Get slider of the health bar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health)// set the max health to a certain value
    {
        slider.maxValue = health;//set the max health
        slider.value = health;//set the health to the max
    }

    public void SetHealth(int health)//set the health bar to a certain value
    {
        slider.value = health;//set the health
    }
}
