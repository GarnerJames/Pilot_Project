using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_trigger : MonoBehaviour
{
    public GameObject uiImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiImage.SetActive(false);
        }
    }
}
