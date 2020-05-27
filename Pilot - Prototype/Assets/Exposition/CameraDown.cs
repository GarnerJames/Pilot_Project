using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDown : MonoBehaviour
{

    public float downRate;
    public float upRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > 590)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + downRate, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 1030)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + upRate, transform.position.z);
        }
    }
}
