using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    public GameObject cloud;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(5, 20);

        Invoke("Spawn", waitTime);
    }

    void Spawn()
    {
        StartCoroutine("CloudTime");
    }

    public IEnumerator CloudTime()
    {
        var cloudInstance = Instantiate(cloud, transform.position, transform.rotation);
        cloudInstance.transform.parent = gameObject.transform;
        waitTime = Random.Range(30, 60);
        yield return new WaitForSeconds(waitTime);
        Spawn();
        yield return null;
    }
}
