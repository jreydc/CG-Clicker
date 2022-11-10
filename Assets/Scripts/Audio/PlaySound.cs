using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    public AudioSource click, buy, squawck;

    public GameObject mute, unmute;

    private float pitchVal;

    private void Awake()
    {
        unmute.SetActive(false);
    }

    public void Mute()
    {
        click.volume = 0;
        buy.volume = 0;
        squawck.volume = 0;

        mute.SetActive(false);
        unmute.SetActive(true);
    }

    public void UnMute()
    {
        click.volume = 0.3f;
        buy.volume = 0.3f;
        squawck.volume = 0.3f;

        mute.SetActive(true);
        unmute.SetActive(false);
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
