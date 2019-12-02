using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool canFall;
    private void OnTriggerEnter(Collider other)
    {
        //turn on gravity for platform if the platform can fall;
        if (other.GetComponent<Player>())
        {
            if (canFall)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }
            //else attaches the player to the platform so the player will move with the platform
            else
            {
                other.transform.parent = transform;
            }
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.transform.parent = null;
        }
    }
}
