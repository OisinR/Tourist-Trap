using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestinationChooser : MonoBehaviour
{
    MoveToWaypoint waypointScript;
    Spawn spawnScript;
    LineRenderer line;
    Satisfaction satScript;
    string[] placestoGo = {"Red","Purple","Yellow","Blue" };
    Text uiText;
    public string destination;
    public bool selected;
    public bool reached;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        waypointScript = GetComponent<MoveToWaypoint>();
        satScript = GetComponent<Satisfaction>();
        spawnScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Spawn>();
        destination = placestoGo[Random.Range(0, 4)];
        selected = false;
        uiText = GameObject.FindGameObjectWithTag("Destination").GetComponent<Text>();
    }

    
    void Update()
    {
        if (selected)
        {
            uiText.text = "Destination: " + destination;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == destination)
        {
            reached = true;
            //Debug.Log("Reached");
            destination = "Out";
        }

        if (other.tag == "Gate" && reached)
        {
            satScript.addScore();
            //Debug.Log("Out");
            Destroy(waypointScript.waypoint);
            line.enabled = false;
            Destroy(gameObject);
        }
    }


}
