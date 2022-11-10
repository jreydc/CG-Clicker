using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMute : MonoBehaviour
{
    public AudioSource bg;

    public GameObject mute, unmute;

    private void Awake()
    {
        unmute.SetActive(false);
    }

    public void Mute()
    {
        bg.volume = 0f;

        mute.SetActive(false);
        unmute.SetActive(true);
    }

    public void UnMute()
    {
        bg.volume = 0.1f;

        mute.SetActive(true);
        unmute.SetActive(false);
    }
}
