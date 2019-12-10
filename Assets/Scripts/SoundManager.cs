using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void OnEnable()
    {
        Diary.playDiary += PlaySound;
    }

    private void OnDisable()
    {
        Diary.playDiary -= PlaySound;
    }

    //when the event triggers, this takes the given source and clip and plays the sound
    void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
