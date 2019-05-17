using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToWaypoint : MonoBehaviour
{
    public GameObject waypoint;
    NavMeshAgent agent;
    Collider col;

    Animator[] animators;
    bool safe;
    public int key;
    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (waypoint != null && agent != null)
        {


            agent.SetDestination(waypoint.transform.position);
            GetComponent<DrawNavMeshPath>().ShowPath(agent.path.corners);



            foreach (Animator anim in animators)                                                                                        //tourist animations
            {
                if (Vector3.Distance(anim.gameObject.transform.position, waypoint.gameObject.transform.position) > 1f)
                {
                    anim.SetBool("Walking", true);
                }
                else
                {
                    anim.SetBool("Walking", false);
                }
            }
        }

    }


    private void OnTriggerEnter(Collider other)                                                     //collisions
    {
        if (other == waypoint && other.gameObject.layer != 9)
        {
            Destroy(other.gameObject);

        }
        if (other.tag == "SafeZone" || other.tag == "Gate")
        {
            
            safe = true;
        }

        gameObject.GetComponentInParent<DestinationChooser>().TriggerReached(other);






        if (other.gameObject.tag == "Tourist" && !safe)
        {
            if(other.gameObject.GetComponent<MoveToWaypoint>().key != key)
            {
                Debug.Log("End");

                GameObject.FindGameObjectWithTag("Manager").GetComponent<Spawn>().gameover = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SafeZone")
        {
            
            safe = false;
        }
    }

}
