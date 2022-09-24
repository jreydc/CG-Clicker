using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesAnimators : MonoBehaviour
{
    public Animator anim;
    public GameObject openButton, closeButton;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        closeButton.SetActive(false);
        openButton.SetActive(true);
    }

    public void Open()
    {
        anim.Play("Open");
        closeButton.SetActive(true);
        openButton.SetActive(false);
    }

    public void Close()
    {
        anim.Play("Close");
        closeButton.SetActive(false);
        openButton.SetActive(true);
    }
}
