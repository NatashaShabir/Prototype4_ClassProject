using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightBulb; //the light object that the switch will turn on/off
    public GameObject lightSource; //the light source of the light object
    public Material lit; //material of the light object
    public Material unlit;

    public bool isOn;

    Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        
    }

    /*public void On()
    {
        lightBulb.GetComponent<Renderer>().material = lit;
        lightSource.SetActive(true);
        isOn = true;
    }

    public void Off()
    {
        lightBulb.GetComponent<Renderer>().material = unlit;
        lightSource.SetActive(false);
        isOn = false;
    }*/

    //if clicked on
    public void Clicked()
    {
        if (!isOn)
        {
            Switch();
        }
    }
    void Switch()
    {
        isOn = true;
        animator.SetBool("switched", true);
        StartCoroutine(LightOn());
    }

    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(1);
        lightSource.SetActive(true);
        //lightBulb.GetComponent<Renderer>().material = lit;
    }
}
