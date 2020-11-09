using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    public AudioSource bgmObj;

    void Update()
    {
        if (PauseMenuScript.isPaused)
        {
            bgmObj.Pause();
        }
        else
        {
            bgmObj.UnPause();
        }
    }
}
