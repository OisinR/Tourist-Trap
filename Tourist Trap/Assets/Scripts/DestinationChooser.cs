using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestinationChooser : MonoBehaviour
{
    MoveToWaypoint waypointScript;
    LineRenderer line;
    Satisfaction satScript;
    ExitMap exitMapScript;
    string[] placestoGo = {"Gazebo","Statue","Fountain","Stone Head" };
    Text uiText;
    public string destination;
    public bool selected;
    public bool reached;
    GameObject lookPoint;
    void Awake()
    {
        
        line = GetComponent<LineRenderer>();
        waypointScript = GetComponent<MoveToWaypoint>();
        satScript = GetComponent<Satisfaction>();
        exitMapScript = GetComponent<ExitMap>();
        destination = placestoGo[Random.Range(0, 4)];                                       //sets the tourist destination on spawn
        selected = false;
        uiText = GameObject.FindGameObjectWithTag("Destination").GetComponent<Text>();
        
    }

    
    void Update()
    {
        if (selected)
        {
            uiText.text = "" + destination;
        }
    }

    public void TriggerReached(Collider other)
    {
        if (other.tag == destination)                                                               //if they've reached theit destination, lets the player know they can leave
        {
            reached = true;
            //Debug.Log("Reached");
            destination = "Out";
        }

        if (other.tag == "Gate" && reached)
        {
            Debug.Log("Exit Attempted");
            lookPoint = other.GetComponent<ExitMapInfo>().GetInfo();    
            exitMapScript.Exit(lookPoint);
        }

        if (other.tag == "DespawnPoint" && reached)
        {
            Destroy(gameObject);
        }
    }


}
