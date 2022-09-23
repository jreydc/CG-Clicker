using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour
{
    public Button clicker;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hover()
    {
        anim.Play("Hover");
    }

    public void UnHover()
    {
        anim.Play("UnHover");
    }

    public void Click()
    {
        anim.Play("Click");
    }

    public void UnClick()
    {
        anim.Play("UnClick");
    }
}
