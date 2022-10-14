using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClickText : MonoBehaviour
{
    public GameObject text;

    public void Spawn()
    {
        Instantiate(text, Input.mousePosition, transform.rotation);
    }
}
