using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDavid : MonoBehaviour
{
    public GameObject cube;
    public GameObject player;
    public new GameObject light;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (light.GetComponent<LightSwitch>().isOn)
            {
                light.GetComponent<LightSwitch>().Off();
            }
            else
            {
                light.GetComponent<LightSwitch>().On();
            }
        }
    }
}
