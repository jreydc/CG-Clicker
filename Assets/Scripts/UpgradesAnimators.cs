using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesAnimators : MonoBehaviour
{
    public Animator anim;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (!isOpen)
        {
            anim.Play("Open");
            isOpen = true;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            anim.Play("Close");
            isOpen = false;
        }
    }
}
