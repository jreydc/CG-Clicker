using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGlowAnimation : MonoBehaviour
{
    SpriteRenderer rend;
    public MaterialPropertyBlock mat;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Animate()
    {
        //mat.outline_switch = 1;
    }
}
