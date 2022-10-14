using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource click, buy;

    private float pitchVal;
    void Start()
    {
        
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
}
