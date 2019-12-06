using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector sceneDirector;
    public bool reloading = false;

    private void OnEnable()
    {
        sceneDirector.stopped += TimelineEnded;
    }

    private void OnDisable()
    {
        sceneDirector.stopped -= TimelineEnded;
    }

    public void Play()
    {
        sceneDirector.Play();

    }

    public void Pause()
    {
        sceneDirector.Pause();
    }

    public void Resume()
    {
        sceneDirector.Resume();
    }

    private void TimelineEnded(PlayableDirector director)
    {
        if(sceneDirector == director)
        {
            if (reloading == true)
            {
                GameManager.instance.ReloadScene();
                reloading = false;
            }
            else
            {
                GameManager.instance.EndScene();
            }
        }
    }
}
