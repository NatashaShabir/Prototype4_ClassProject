using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDetection : MonoBehaviour
{
    private AreWeInPosition playerPosCheck;

    private float countdown = 0;
    public float countdownReset = 5;
    public float timeToMove = 3;

    private bool startTimer = false;
    private bool onStage = false;

    public Text counter;
    public Text PressE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           Debug.Log("We Found the Player");
           playerPosCheck = other.GetComponent<AreWeInPosition>();
           countdown = countdownReset;
           startTimer = true;
           onStage = true;
           PressE.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Left the Stage");
            counter.gameObject.SetActive(false);
            PressE.gameObject.SetActive(false);
            onStage = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onStage == true)
        {
            if (startTimer == true)
            {
                countdown -= Time.fixedDeltaTime;
                counter.text = countdown.ToString("0");

                if (playerPosCheck != null)
                {
                    if (playerPosCheck.wePosed == true)
                    {
                        startTimer = false;
                    }
                }

                if (countdown <= timeToMove)
                {
                    counter.gameObject.SetActive(true);
                    PressE.gameObject.SetActive(false);
                }

                if (countdown <= 1)
                {
                    startTimer = false;
                }
            }

            else if (startTimer == false)
            {
                counter.gameObject.SetActive(false);

                if (playerPosCheck != null)
                {
                    if (playerPosCheck.wePosed == true)
                    {
                        if (playerPosCheck.rightColourChosen == true)
                        {
                            countdown = countdownReset;
                            startTimer = true;
                            playerPosCheck.wePosed = false;
                            PressE.gameObject.SetActive(true);

                        }
                        else if (playerPosCheck.rightColourChosen == false)
                        {
                            Debug.Log("The Player failed");
                            countdown = countdownReset;
                            startTimer = true;
                            playerPosCheck.wePosed = false;
                            PressE.gameObject.SetActive(true);
                        }

                    }

                }

            }
        }        

    }
}
