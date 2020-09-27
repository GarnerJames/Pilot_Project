using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {

        transform.LookAt(player);

        
    }
}
