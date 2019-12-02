using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;

    public bool canInteract;

    void Update()
    {
        //detects if what the player is looking at can be interacted with
        //interactable objects will have the Interactable tag
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            if (hit.transform.tag == "Interactable")
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        else
        {
            canInteract = false;
        }

        //if the player clicks on something that can be interacted with
        if (Input.GetMouseButtonDown(0))
        {
            if (canInteract)
            {
                InteractClick(hit.transform.gameObject);
            }
        }
    }

    void InteractClick(GameObject obj)
    {
        if (obj.GetComponent<LightSwitch>())
        {
            obj.GetComponent<LightSwitch>().Clicked();
        }
    }
}
