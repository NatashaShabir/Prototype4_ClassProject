using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDavid : MonoBehaviour
{
    public GameObject cube;
    public GameObject player;
    public new GameObject light;

    public delegate void TheatreWalls();
    public static TheatreWalls Shrink;
    public static TheatreWalls Grow;
    public static TheatreWalls Pause;


    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Shrink();
        }

        if (Input.GetKeyDown("r"))
        {
            Grow();
        }

        if (Input.GetKeyDown("t"))
        {
            Pause();
        }
    }
}
