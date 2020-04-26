using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTest : MonoBehaviour
{

    public GameObject Chunk1;
    public GameObject Chunk3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Chunk1.SetActive(false);
            Chunk3.SetActive(true);
        }
    }
}
