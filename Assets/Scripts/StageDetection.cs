using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageDetection : MonoBehaviour
{
    public TimelineController timeline; //reference to timeline script on director
    private AreWeInPosition playerPosCheck; //reference to are we in position script on player

    //Floats for the coundown timer
    private float countdown = 0;
    public float countdownReset = 5; //What to reset it to
    public float timeToMove = 3; //At what time do we switch from press e text to counter text

    //Bools to check whether we should start the timer and whether the player is actually on stage
    private bool startTimer = false;
    private bool onStage = false;

    //References to Ui
    public Text counter;
    public Text PressE;

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the stage set a reference to the are we in position script
        //set the countdown, tell the timer to start, set on stage to true, and show the press e text

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
        //if the player leaves the stage get rid of the text Ui, and set on stage to false

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
                //If we can start the timer, then lets start taking time away from the countdown variable

                countdown -= Time.fixedDeltaTime;
                counter.text = countdown.ToString("0"); //set the counter text to equal the countdown variable

                if (playerPosCheck != null)
                {
                    //If player sets their position during a countdown cancel the timer and move onto checking if they got the colour right

                    if (playerPosCheck.wePosed == true)
                    {
                        startTimer = false;
                    }
                }

                if (countdown <= timeToMove)
                {
                    //Once the timer reaches the time they have to move then switch the active text from press e to counter

                    counter.gameObject.SetActive(true);
                    PressE.gameObject.SetActive(false);
                }

                if (countdown <= 1)
                {
                    //if the countdown goes below 1 then check if the player posed, if not reset the level

                    if (playerPosCheck.wePosed != true)
                    {
                        counter.gameObject.SetActive(false);
                        PressE.gameObject.SetActive(false);

                        startTimer = false;

                        timeline.reloading = true;
                        timeline.Play();
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
                                timeline.Play();
                                Debug.Log("The Player failed");
                                
                            }

                        }

                    }
                }
            }
        }
    }
}

