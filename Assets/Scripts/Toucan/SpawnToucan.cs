using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnToucan : MonoBehaviour
{
    public GameObject toucan;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(120, 421);

        Invoke("Spawn", waitTime);
        print("waiting for " + waitTime + " seconds");
    }

    // Update is called once per frame
    void Spawn()
    {
        StartCoroutine("ToucanTime");
    }

    public IEnumerator ToucanTime()
    {
        var toucInstance = Instantiate(toucan, transform.position, transform.rotation);
        toucInstance.transform.parent = gameObject.transform;
        waitTime = Random.Range(120, 421);
        print("waiting for " + waitTime + " seconds");
        yield return new WaitForSeconds(waitTime);
        Spawn();
        print("here we go again!");
        yield return null;
    }
}
