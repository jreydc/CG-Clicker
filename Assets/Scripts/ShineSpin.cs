using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShineSpin : MonoBehaviour
{
    public Vector3 rotationDirection;
    public float smoothTime;
    private float convertedTime = 50;
    private float smooth;

    SpriteRenderer image;

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        image.color = new Color(1, 1, 1, 0);
    }

    public void On()
    {
        image.color = new Color(1, 1, 1, 1);
    }

    public void Off()
    {
        image.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        smooth = Time.deltaTime * smoothTime * convertedTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
