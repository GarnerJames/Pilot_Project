using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public GameObject brokenVersion;
    public GameObject aiVoice;

    public void TakeDamage()
    {

        Invoke("Die", 0.4f);
        aiVoice.GetComponent<aiVoice_trigger_end>().voice();
        
    }

    void Die()
    {
        Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
