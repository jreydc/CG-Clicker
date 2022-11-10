using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMute : MonoBehaviour
{
    public AudioSource bg;
    
    public void Mute()
    {
        bg.volume = 0f;
    }

    public void UnMute()
    {
        bg.volume = 0.1f;
    }
}
