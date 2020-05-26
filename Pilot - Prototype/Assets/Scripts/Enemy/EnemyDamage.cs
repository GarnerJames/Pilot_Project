using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    Animator animator;

    BoxCollider col;

    public GameObject light;

    private void Start()
    {
        animator = GetComponent<Animator>();

        col = GetComponent<BoxCollider>();
    }

    public void TakeDamage()
    {
        Die();
    }

    void Die()
    {
        animator.enabled = false;
        col.enabled = false;
        light.SetActive(false);
    }
}
