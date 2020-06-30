using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    public Vector3 playerPos;

    public GameObject checkpointOne;
    public GameObject checkpointTwo;
    public GameObject checkpointThree;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = playerPos;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckpointOne")
        {
            playerPos = checkpointOne.transform.position;
        }

        if (other.tag == "CheckpointTwo")
        {
            playerPos = checkpointTwo.transform.position;
        }

        if (other.tag == "CheckpointThree")
        {
            playerPos = checkpointThree.transform.position;
        }
    }

    void Reload()
    {
        gameObject.transform.position = playerPos;
        animator.enabled = true;
    }
}
