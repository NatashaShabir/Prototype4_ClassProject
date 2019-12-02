using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightObject; //the light object that the switch will turn on/off
    public GameObject spotlight; //the light source of the light object
    public Material lit; //material of the light object
    public Material unlit;

    public bool isOn;

    void Start()
    {
        if (isOn)
        {
            On();
        }
        else
        {
            Off();
        }
    }

    void Update()
    {
        
    }

    public void On()
    {
        lightObject.GetComponent<Renderer>().material = lit;
        spotlight.SetActive(true);
        isOn = true;
    }

    public void Off()
    {
        lightObject.GetComponent<Renderer>().material = unlit;
        spotlight.SetActive(false);
        isOn = false;
    }

    //if clicked on
    public void Clicked()
    {
        if (isOn)
        {
            Off();
        }
        else
        {
            On();
        }
    }
}
