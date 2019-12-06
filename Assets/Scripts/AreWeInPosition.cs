using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreWeInPosition : MonoBehaviour
{
    //hold the spotlight we are standing under
    public GameObject whatLightAreWeUnder;

    //what is the curret
    int poseNumber = 0;

    //where we are getting our colour choices from
    public GameObject colourSelector;
    Material fistColour;
    Material secondColour;
    Material thirdColour;

    public bool wePosed = false;
    public bool rightColourChosen = false;

    // Start is called before the first frame update
    void Start()
    {
        fistColour = colourSelector.GetComponent<TheatreColourSelections>().firstColourChoice;
        secondColour = colourSelector.GetComponent<TheatreColourSelections>().secondColourChoice;
        thirdColour = colourSelector.GetComponent<TheatreColourSelections>().thirdColourChoice;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
        {
            PoseForCamera();
            wePosed = true;
        }
    }

    //trigger current selection
    void PoseForCamera()
    {

        if (poseNumber == 0)
        {
            CheckPoseColour(fistColour);
            poseNumber += 1;
        }
        else if (poseNumber == 1)
        {
            CheckPoseColour(secondColour);
            poseNumber += 1;
        }
        else if (poseNumber == 2)
        {
            CheckPoseColour(thirdColour);
            poseNumber += 1;
        }


        //Debug.Log(poseNumber);

    }
    //Check if we selected the right colour
    void CheckPoseColour(Material x)
    {
        if (x.name + " (Instance)" == whatLightAreWeUnder.GetComponent<Renderer>().material.name)
        {
            Debug.Log("What A Great Pose. Clap,Clap,Clap,Clap,Clap,Clap!!");
            rightColourChosen = true;
        }
        else
        {
            Debug.Log("Boooo!!! Your Standing In the WRONG Place!!!");
            rightColourChosen = false;
        }

       // Debug.Log(whatLightAreWeUnder.GetComponent<Renderer>().material.name + "" + x.name);

        
    }


    //hold the details of the object we collide with 
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            whatLightAreWeUnder = col.gameObject;

        }
    }

    //disable components when out of range
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            whatLightAreWeUnder = null;
        }
    }
}
