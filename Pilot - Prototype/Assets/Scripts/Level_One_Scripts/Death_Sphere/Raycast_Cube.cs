using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Cube : MonoBehaviour
{
    public GameObject player;
    public bool follow = false;
    public LayerMask mask;

    private void Update()
    {
        if (follow)
        {
            gameObject.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast (ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

            if (hitInfo.collider.gameObject.tag == "Player")
            {
                Invoke("Hit", 0.5f);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }

    }

    void Hit()
    {
        player.GetComponent<PlayerController>().Die();
        //death sphere shoot
    }
}
