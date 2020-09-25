using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public GameObject brokenVersion;
    public GameManager gm;
    public AudioSource die;

    public void TakeDamage()
    {

        Invoke("Die", 0.4f);
        gm.GetComponent<GameManager>().End();
        
    }

    void Die()
    {
        Instantiate(brokenVersion, transform.position, transform.rotation);
        die.Play();
        Destroy(gameObject);
    }

}
