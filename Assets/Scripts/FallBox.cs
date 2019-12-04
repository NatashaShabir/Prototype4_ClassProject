using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be attached to a collision box
//once triggered it should port the player to the attached transform
public class FallBox : MonoBehaviour
{
    public Transform destination; //every object this script is attached to should have a transform manually attached to it

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (destination != null)
            {
                other.transform.position = destination.position;
            }
        }

        if (other.GetComponent<Platform>() && other.GetComponent<Platform>().canRespawn)
        {
            other.GetComponent<Platform>().Spawn();
        }
    }
}
