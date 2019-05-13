using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaypoint : MonoBehaviour
{
    Camera screenCamera;
    public GameObject prefab;
    GameObject destination;
    MoveToWaypoint waypointScript;
    SelectedGroup currentGroup;
    public Material player, selected, waypointSelected, waypointUnselected;
    bool first = true;
    GameObject destinationWaypoint;

    private void Start()
    {
        screenCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);

            int layerMask = 1 << 9;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (waypointScript != null)
                {
                    if (waypointScript.waypoint != null && waypointScript.waypoint.layer != 11)
                    {
                        Destroy(waypointScript.waypoint);
                    }
                    destination = Instantiate(prefab, hit.point, Quaternion.identity);
                    currentGroup.destinationWaypoint = destination;
                    currentGroup.Selected();
                   // waypointScript.waypoint.GetComponent<Renderer>().material = waypointSelected;
                }
            }
        }
        if (Input.GetMouseButtonDown(0)) //Rightclick
        {
            RaycastHit hit;
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << 10;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (first)
                {
                    first = false;
                    currentGroup = hit.transform.parent.gameObject.GetComponent<SelectedGroup>();
                    currentGroup.Selected();
                }
                else
                {
                    if (waypointScript.waypoint != null)
                    {
                        waypointScript.waypoint.GetComponent<Renderer>().material = waypointUnselected;
                    }
                    if(currentGroup != null)
                    {
                        currentGroup.UnSelected();

                    }

                    currentGroup = hit.transform.parent.gameObject.GetComponent<SelectedGroup>();
                    currentGroup.Selected();
                }
                waypointScript = hit.transform.parent.gameObject.GetComponent<MoveToWaypoint>();
                if (waypointScript.waypoint != null)
                {
                    waypointScript.waypoint.GetComponent<Renderer>().material = waypointSelected;
                }
            }
        }
    }
}

