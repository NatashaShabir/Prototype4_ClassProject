using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be attached to a collision box
//once triggered it should port the player to the attached transform
public class FallBox : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.transform.position = destination.position;

            //other.transform.SetPositionAndRotation(destination.position, destination.rotation);
        }
    }
}
