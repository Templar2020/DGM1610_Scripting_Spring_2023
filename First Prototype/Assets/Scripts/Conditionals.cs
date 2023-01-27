using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{

    int time = 104;
    public string weather = "Clear";
    bool isStopLightRed = true;
    float gpa = 3.25f;
    double temperature = 101.45d;


    // Start is called before the first frame update
    void Start()
    {
        //Check Time
        if(time >= 200)
        {
            Debug.Log("Rise and Shine!");
        }
        else
        {
            Debug.Log("Its too early go back to bed!");
        }


        /*

        if(conditional_01)
        {
            //If condition_01 is true run this code
        }
        else if(conditional_02)
        {
            //If condition_02 is true run this code
        }
        else
        {
            //If no other conditions are true run this code
        }

        */
        

    }

    // Update is called once per frame
    void Update()
    {
        // Check Weather
        if(weather == "Cloudy")
        {
            Debug.Log("It is cloudy outside");
        }
        else if (weather == "Raining")
        {
            Debug.Log("It is raining outside!");
        }
        else if (weather == "Clear")
        {
            Debug.Log("It is a beautiful day outside!");
        }
        else if (weather == "ThunderLightning")
        {
            Debug.Log("There is thunder and lightning outside, stay indoors!!!");
        }
        else if (weather == "Snowing")
        {
            Debug.Log("It is snowing outside, bunde up it is cold!");
        }
        else
        {
            Debug.Log("Do what you want! Its a day!");
        }
    }
}
