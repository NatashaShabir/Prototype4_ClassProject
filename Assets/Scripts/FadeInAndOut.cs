using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour
{
    //speed to fade in
    public float fadeSpeed = 1f;
    //what is our current fade
    float currentFade = 0f;
    //when do we fade
    public bool shouldWeFade;
    //do we need to fade to in or out
    public bool fadeToBlack;
    //should the sceen start black
    public bool startBlack;

    //record if this is the first fade
    public bool switchSceneAtEndOfFade = false;

    public string SceneToSwapTo;

    public bool resetScene = false;


    void Start()
    {
        if (fadeToBlack == true)
        {
            currentFade = 100f;
        }
        else
        {
            currentFade = 0f;
        }

        if (startBlack == true)
        {
            this.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            this.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    void Update()
    {
        //swap sceen if needed
        swapScene();

        //fade in and out based off of our bools
        if (shouldWeFade == true)
        {
            if(fadeToBlack == true)
            {
                FadeBlack();
            }
            else
            {
                FadeClear();
            }
        }
    }

    void FadeClear()
    {
        if(currentFade != 100)
        {
            currentFade += fadeSpeed;
            this.GetComponent<CanvasGroup>().alpha = (100 - currentFade) / 100;
        }
        
    }

    void FadeBlack()
    {
        if (currentFade != 0)
        {
            currentFade -= fadeSpeed;
            this.GetComponent<CanvasGroup>().alpha = (100 - currentFade) / 100;
        }
    }

    //let the scene switch if needed
    void swapScene()
    {
        if (switchSceneAtEndOfFade == true)
        {
            if (currentFade == 100 && fadeToBlack == false || currentFade == 0 && fadeToBlack == true)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
                {
                    if(resetScene == false)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }

                    
                }
                
            }
        }
    }
}
