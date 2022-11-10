using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource click, buy, squawck;

    private float pitchVal;
    public void Mute()
    {
        click.volume = 0;
        buy.volume = 0;
        squawck.volume = 0;
    }

    public void UnMute()
    {
        click.volume = 0.3f;
        buy.volume = 0.3f;
        squawck.volume = 0.3f;
    }

    // Update is called once per frame
    public void Click()
    {
        pitchVal = Random.Range(1f, 1.5f);

        click.pitch = pitchVal;
        click.Play();
    }

    public void Buy()
    {
        pitchVal = Random.Range(1f, 1.3f);

        buy.pitch = pitchVal;
        buy.Play();
    }

    public void Sqwack()
    {
        pitchVal = Random.Range(1f, 1.3f);

        squawck.pitch = pitchVal;
        squawck.Play();
    }
}
