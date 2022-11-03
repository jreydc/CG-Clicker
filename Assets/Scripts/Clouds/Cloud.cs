using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(10, 36);
        Invoke("Die", 120);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
