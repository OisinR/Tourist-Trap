using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristCollision : MonoBehaviour
{

    public int key;
	void Start()
    {
        key = Random.Range(-1000,1000);                                         //sets keys for tourist collisions to be used with Keys script


        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<MoveToWaypoint>().key = key;
        }
    }
}

