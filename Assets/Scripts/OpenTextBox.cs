using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTextBox : MonoBehaviour
{
    Animator textAnimation;

    // Start is called before the first frame update
    void Start()
    {
        textAnimation = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeTextBoxStatus();
        }
        
    }

    public void ChangeTextBoxStatus()
    {
        if(textAnimation.GetBool("Open") == true)
        {
            textAnimation.SetBool("Open", false);
        }
        else
        {
            textAnimation.SetBool("Open", true);
        }

    }
}
