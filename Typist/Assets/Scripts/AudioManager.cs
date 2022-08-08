using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip mainMenuBGM;

    [SerializeField]
    AudioClip inGameBGM;

    [SerializeField]
    AudioClip resultsBGM;

    public void Awake()
    {
        PlayMainMenuBGM();
    }

    public void PlayMainMenuBGM()
    {
        audioSource.clip = mainMenuBGM;
        audioSource.Play();
    }

    public void PlayInGameBGM()
    {
        audioSource.clip = inGameBGM;
        audioSource.Play();
    }

    public void PlayResultsBGM()
    {
        audioSource.clip = resultsBGM;
        audioSource.Play();
    }

    public void PauseBGM()
    {
        audioSource.Pause();
    }

    public void ResumeBGM()
    {
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
