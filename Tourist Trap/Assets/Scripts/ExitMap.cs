using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExitMap : MonoBehaviour
{

    MoveToWaypoint waypointScript;
    public GameObject lookPoint;
    Spawn spawnScript;
    bool exiting;
    public int test;
    void Start()
    {
        spawnScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Spawn>();
        waypointScript = GetComponent<MoveToWaypoint>();
    }




	void Update()
    {
        if (lookPoint != null)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.transform.LookAt(lookPoint.transform);
                child.transform.position += child.transform.forward * 0.2f;
            }
        }

    }




    public void Exit(GameObject exit)
    {
        if (exiting) { return; }
        exiting = true;
        test++;
        lookPoint = exit;
        spawnScript.touristOut();
        GetComponent<Satisfaction>().addScore();
        Debug.Log("Out");
        Destroy(waypointScript.waypoint);

        Collider[] allColliders = GetComponentsInChildren<Collider>();
        foreach (Collider childCollider in allColliders)
        {
            Destroy(childCollider);
        }

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<LineRenderer>().enabled = false;
            GameObject.Destroy(child.gameObject.GetComponent<NavMeshAgent>());

        }



    }

}
