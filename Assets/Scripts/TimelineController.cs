using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector sceneDirector;

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
}
