using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorGuy : MonoBehaviour
{
    public Animator ani;

    private void OnTriggerEnter(Collider other)
    {
        ani.SetBool ("Push", true);
    }
}
