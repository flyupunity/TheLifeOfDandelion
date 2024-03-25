using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pauseInShowingAd : MonoBehaviour
{
    public void AdStarted()
    {
        Progress.Instance.adShowing = true;
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }
    public void AdEnded()
    {
        Progress.Instance.adShowing = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
}
