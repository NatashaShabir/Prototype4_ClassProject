using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diary : MonoBehaviour
{
    AudioSource mySource;
    public AudioClip diaryClip; //the clip the diary plays should be attached manually

    public delegate void DiaryEntry(AudioSource source, AudioClip clip);
    public static DiaryEntry playDiary;

    public delegate void DiaryFinish();
    public static DiaryFinish finish;

    bool clicked;

    public GameObject textBoxPannel;
    public string dairyText;

    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    public void Clicked()
    {
        //trigger playDiary event and send audio source and clip
        if (diaryClip != null)
        {
            playDiary(mySource, diaryClip);
            textBoxPannel.GetComponent<OpenTextBox>().SetTextAndOpen(dairyText);
        }

        if (!clicked)
        {
            clicked = true; //ensures this triggers once
            StartCoroutine(DoorTrigger()); //this starts a timer that ends when the clip finishes playing
        }
    }

    IEnumerator DoorTrigger()
    {
        if (diaryClip != null)
        {
            yield return new WaitForSeconds(diaryClip.length + 0.5f);
        }
        else
        {
            yield return new WaitForSeconds(.5f);
        }
        

        if (GameManager.instance != null)
        {
            textBoxPannel.GetComponent<OpenTextBox>().CloseTextBox();
            finish(); //trigger finish event which the GameManager should be listening to and trigger the end scene function
        }
        else
        {
            //if there isn't a game manager then manually load the next scene. this is for testing purposes
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
    }
}
