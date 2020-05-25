using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public Rigidbody rb;

    public Animator ani;

    public GameObject spotLight;

    public float sideForce;
    public float backForce;
    public float upForce;

    private void Start()
    {
        //box.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage()
    {
        Die();
    }

    void Die()
    {
        ani.enabled = false;

        spotLight.SetActive(false);

        rb.AddForce(sideForce, upForce, backForce, ForceMode.VelocityChange);
    }
}
