using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNavMeshPath : MonoBehaviour
{
    Vector3[] path = new Vector3[0];

    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (path != null && path.Length > 1)                                //draws out the path that the navmesh agent is going to take
        {
            lr.positionCount = path.Length;
            for (int i = 0; i < path.Length; i++)
            {
                lr.SetPosition(i, path[i]);
            }
        }
    }

    public void ShowPath(Vector3[] import)
    {

        path = import;
    }

}