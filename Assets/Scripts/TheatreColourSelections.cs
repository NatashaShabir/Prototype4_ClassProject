using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheatreColourSelections : MonoBehaviour
{

    public List<Material> OurColoursChoices;

    public GameObject[] boxsToChangeColour;


    public Material[] CurrentDrawColours;

    public Material firstColourChoice;
    public Material secondColourChoice;
    public Material thirdColourChoice;

    public GameObject boxColour1;
    public GameObject boxColour2;
    public GameObject boxColour3;


    void Start()
    {
        SetColours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //select colours for theatre
    void SetColours()
    {
        int i = Random.Range(0, OurColoursChoices.Count);
        firstColourChoice = OurColoursChoices[i];
        OurColoursChoices.Remove(firstColourChoice);

        int x = Random.Range(0, OurColoursChoices.Count);
        secondColourChoice = OurColoursChoices[x];
        OurColoursChoices.Remove(secondColourChoice);

        int y = Random.Range(0, OurColoursChoices.Count);
        thirdColourChoice = OurColoursChoices[y];
        OurColoursChoices.Remove(thirdColourChoice);

        boxColour1.GetComponent<Renderer>().material = firstColourChoice;
        boxColour2.GetComponent<Renderer>().material = secondColourChoice;
        boxColour3.GetComponent<Renderer>().material = thirdColourChoice;
    }
    

}
