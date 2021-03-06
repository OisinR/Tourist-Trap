﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Satisfaction : MonoBehaviour
{
    Score scoreScript;
    DestinationChooser destChooser;
    NavMeshAgent agent;
    public float satisfaction;
    float decayRate;
    Text satisfactionText;
    public bool display;
    public bool waiting,going,atDest;

    void Awake()
    {

        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();
        destChooser = GetComponent<DestinationChooser>();
        agent = GetComponentInChildren<NavMeshAgent>();
        satisfactionText = GameObject.FindGameObjectWithTag("Satisfaction").GetComponent<Text>();
        decayRate = 5f;
        satisfaction = 100;
    }


    void Update()
    {
        if (agent != null && agent.hasPath)                                 //satisfaction goes down slower if the group is moving
        {
            going = true;
            waiting = false;

        }
        else
        {
            going = false;
            StartCoroutine(DecayDelay());

        }




        if(waiting && !atDest)
        {
            satisfaction -= decayRate * Time.deltaTime;
        }
        if(going)
        {
            satisfaction -= decayRate * 0.1f * Time.deltaTime;
        }

        if (satisfaction <= 0)
        {
            satisfaction = 0;
        }

        if (display)
        {
            satisfactionText.text = "" + (int)satisfaction;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == destChooser.destination)
        {
            atDest = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == destChooser.destination)
        {
            atDest = false;
        }
    }


    public void addScore()
    {
        scoreScript.displayScore(satisfaction);
    }


    IEnumerator DecayDelay()
    {
        yield return new WaitForSeconds(1.5f);
        waiting = true;
    }
}
