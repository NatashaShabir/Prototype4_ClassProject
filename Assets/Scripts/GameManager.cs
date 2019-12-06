﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //To reference the GameManager in another script, do: GameManager.instance.whatever_you_need;

    public GameObject fadeCanvasPrefab;
    GameObject fadeCanvas;

    //ensures there's only ever 1 instance of the GameManager and makes it
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); //Makes sure GameManager persists through scene transitions
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneStart;
        Diary.finish += EndScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneStart;
        Diary.finish -= EndScene;
    }

    void SceneStart(Scene scene, LoadSceneMode mode)
    {
        //ANALYTICS
        /*if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Levels(true, false, false, false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Levels(true, true, true, false);
        }*/

        //This is so that the canvas that controls fading in and out doesn't get created during the menu screen
        //The fade canvas made it so that the menu buttons could not be interacted with
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            //creates canvas whenever a scene starts which should automatically fade in from black
            fadeCanvas = Instantiate(fadeCanvasPrefab);
        }

    }

    public void EndScene()
    {
        //ANALYTICS
        /*if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Levels(true, true, false, false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Levels(true, true, true, true);
        }*/

        //start fading mechanics when scene is ending
        if (fadeCanvas != null)
        {
            fadeCanvas.GetComponent<FadeInAndOut>().fadeToBlack = true;
            fadeCanvas.GetComponent<FadeInAndOut>().switchSceneAtEndOfFade = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    //Reset scene on
    public void ResetScene()
    {
        if (fadeCanvas != null)
        {
            fadeCanvas.GetComponent<FadeInAndOut>().fadeToBlack = true;
            fadeCanvas.GetComponent<FadeInAndOut>().switchSceneAtEndOfFade = true;
            fadeCanvas.GetComponent<FadeInAndOut>().resetScene = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    //Analytic stuff
    public void Levels(bool startLevel1, bool endLevel1, bool startLevel2, bool endLevel2)
    {
        Analytics.CustomEvent("LevelProgression", new Dictionary<string, object>
        {
            { "Start1", startLevel1 },
            { "End1", endLevel1 },
            { "Start2", startLevel2 },
            { "End2", endLevel2 }
        });
    }
}
