using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{

    public GameObject player;
    public Transform locationTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.RightControl))
        {
            player.transform.position = locationTo.transform.position;
        }
    }
}
