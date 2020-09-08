using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Ladder_Trig : MonoBehaviour
{
    public Animator ladder;
    public float delayTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("LadderDown", delayTime);
        }
    }

    void LadderDown()
    {
        ladder.SetTrigger("Down");
    }
}
