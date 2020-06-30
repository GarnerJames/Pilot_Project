using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
