using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{

    public static bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            //Change Light Colour
            Debug.Log("Unlocked");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && unlocked)
        {
            Destroy(gameObject);
        }
    }
}
