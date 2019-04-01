using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToWaypoint : MonoBehaviour
{
    public GameObject waypoint;
    NavMeshAgent agent;
    DrawNavMeshPath drawScript;
    Collider col;
    bool safe;
    void Awake()
    {
        drawScript = GetComponent<DrawNavMeshPath>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(waypoint != null)
        {
            agent.SetDestination(waypoint.transform.position);
            DrawNavMeshPath.path = agent.path.corners;
        }  
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == waypoint)
        {
            Destroy(other.gameObject);

        }
        if (other.tag == "SafeZone")
        {
            
            safe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SafeZone")
        {
            
            safe = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tourist" && !safe)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Spawn>().gameover = true;
        }
    }

}
