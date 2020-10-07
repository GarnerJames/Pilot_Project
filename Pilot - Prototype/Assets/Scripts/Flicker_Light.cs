using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker_Light : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    private void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
