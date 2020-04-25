using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public Animator ani;
    public Animator ani1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.RightControl))
        {
            ani.SetBool("Down" , true);
            ani1.SetBool("Switch", true);
        }   
    }
}
