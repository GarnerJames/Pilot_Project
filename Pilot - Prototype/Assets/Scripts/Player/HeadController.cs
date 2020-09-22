using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    protected Animator ani;
    public bool ikActive;
    public Transform lookObj = null;
    public float lookWeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Look")
        {
            ikActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Look")
        {
            ikActive = false;
        }
    }

    void OnAnimatorIK()
    {
        if (ikActive)
        {
            if (lookObj != null)
            {
                ani.SetLookAtWeight(lookWeight);
                ani.SetLookAtPosition(lookObj.position);
            }
        }
        else
        {
            ani.SetLookAtWeight(0);
        }
    }
}
