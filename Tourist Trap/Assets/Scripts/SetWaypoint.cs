using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaypoint : MonoBehaviour
{
    Camera screenCamera;
    public GameObject prefab;
    GameObject destination;
    MoveToWaypoint waypointScript;
    Renderer currentCube;
    public Material player, selected, waypointSelected, waypointUnselected;
    bool first = true;
    DestinationChooser destChoose;
    Satisfaction satScript;

    private void Start()
    {
        screenCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);

            int layerMask = 1 << 9;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (waypointScript != null)
                {
                    //Debug.Log("LC");
                    if (waypointScript.waypoint != null)
                    {
                        Destroy(waypointScript.waypoint);
                    }
                    destination = Instantiate(prefab, hit.point, Quaternion.identity);
                    waypointScript.waypoint = destination;
                    waypointScript.waypoint.GetComponent<Renderer>().material = waypointSelected;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("RC1");
            RaycastHit hit;
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << 10;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                //Debug.Log(hit);
                if (first)
                {
                    first = false;
                    destChoose = hit.transform.gameObject.GetComponent<DestinationChooser>();
                    destChoose.selected = true;
                    currentCube = hit.transform.gameObject.GetComponent<Renderer>();
                    currentCube.material = selected;
                    satScript = hit.transform.gameObject.GetComponent<Satisfaction>();
                    satScript.display = true;
                    
                }
                else
                {
                    if (waypointScript.waypoint != null)
                    {
                        waypointScript.waypoint.GetComponent<Renderer>().material = waypointUnselected;
                    }
                    satScript.display = false;
                    destChoose.selected = false;
                    destChoose = hit.transform.gameObject.GetComponent<DestinationChooser>();
                    destChoose.selected = true;
                    if (currentCube != null)
                    {
                        currentCube.material = player;
                    }
                    currentCube = hit.transform.gameObject.GetComponent<Renderer>();
                    currentCube.material = selected;
                    satScript = hit.transform.gameObject.GetComponent<Satisfaction>();
                    satScript.display = true;
                }
                waypointScript = hit.transform.gameObject.GetComponent<MoveToWaypoint>();
                if (waypointScript.waypoint != null)
                {
                    waypointScript.waypoint.GetComponent<Renderer>().material = waypointSelected;
                }
            }
        }
    }
}

