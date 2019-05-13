using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SetPath : MonoBehaviour
{
    DrawNavMeshPath drawScript;
    NavMeshAgent agent;
    void Awake()
    {
        drawScript = GetComponent<DrawNavMeshPath>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ShowPath()
    {

        //drawScript = agent.path.corners;
    }



}
