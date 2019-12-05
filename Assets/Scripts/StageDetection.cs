using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDetection : MonoBehaviour
{
    private AreWeInPosition playerPosCheck;

    public float countdown = 0;
    public float countdownReset = 3;

    private bool startTimer = false;

    public Text counter;
    public Text PressE;

    // Update is called once per frame
    void Update()
    {
        counter.text = countdown.ToString("0");

            if(countdown >= countdownReset)
            {
                Debug.Log("We're Counting");

                countdown -= Time.fixedDeltaTime;
                counter.gameObject.SetActive(true);
                PressE.gameObject.SetActive(false);

                if (countdown <= 0)
                {
                    if(playerPosCheck != null)
                    {
                        if (playerPosCheck.rightColourChosen == true)
                        {
                            counter.gameObject.SetActive(false);
                            PressE.gameObject.SetActive(true);

                            countdown = countdownReset;
                        }
                        else
                        {
                            Debug.Log("The Player failed");
                        }
                    }
                }
            }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("We Found the Player");
           playerPosCheck = other.GetComponent<AreWeInPosition>();
           countdown = countdownReset;
           //startTimer = true;
        }
    }

}
