using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    private NavMeshAgent Mob;

    public GameObject startLoc;
    public GameObject Player;

    //Animator mobani;

    public float mobDistanceRun;
    public float attackDistance;

    public bool chase = false;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        //mobani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (chase)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < mobDistanceRun)
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position - dirToPlayer;

                Mob.SetDestination(newPos);

                //mobani.SetBool("running", true);
            }

            if (distance < attackDistance)
            {
                Attack();
            }
        }
      
        if (chase == false)
        {
            float distance = Vector3.Distance(transform.position, startLoc.transform.position);

            if (distance < mobDistanceRun)
            {
                Vector3 dirToPlayer = transform.position - startLoc.transform.position;

                Vector3 newPos = transform.position - dirToPlayer;

                Mob.SetDestination(newPos);

                //mobani.SetBool("running", true);
            }
        }

    }

    void Attack()
    {
        //attack animation
        Player.GetComponent<PlayerController>().Die();
        chase = false;
        //reset
    }

}
