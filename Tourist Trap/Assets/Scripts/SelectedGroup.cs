using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGroup : MonoBehaviour
{
    DestinationChooser destChoose;
    Satisfaction satScript;
    MoveToWaypoint moveScript;
    public GameObject destinationWaypoint;
    public Component[] moveScripts;
    HighlightSelected[] highlight;

	void Awake()
    {
        highlight = GetComponentsInChildren<HighlightSelected>();
        destChoose = GetComponent<DestinationChooser>();
        satScript = GetComponent<Satisfaction>();
    }

    private void Update()
    {
        moveScripts = GetComponentsInChildren<MoveToWaypoint>();
        foreach (MoveToWaypoint move in moveScripts)
        {
            move.waypoint = destinationWaypoint;
        }
    }

    public void Selected()
    {
        foreach (HighlightSelected selected in highlight)
        {
            selected.Selected();
        }
        destChoose.selected = true;
        satScript.display = true;
    }

    public void UnSelected()
    {
        foreach (HighlightSelected selected in highlight)
        {
            selected.UnSelected();
        }
        destChoose.selected = false;
        satScript.display = false;
    }

}
