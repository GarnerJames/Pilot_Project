using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public GameObject ragdoll;


    public void TakeDamage()
    {

        Invoke("Die", 0.3f);
        
    }

    void Die()
    {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
