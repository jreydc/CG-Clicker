using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementText : MonoBehaviour
{
    Animator anim;
    public TextMeshProUGUI achName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Play()
    {
        anim.Play("Appear");
    }
}
