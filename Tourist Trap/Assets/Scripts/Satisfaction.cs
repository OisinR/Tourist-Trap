using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Satisfaction : MonoBehaviour
{
    Score scoreScript;
    DestinationChooser destChooser;
    NavMeshAgent agent;
    float satisfaction;
    float decayRate;
    Text satisfactionText;
    public bool display;
    public bool waiting,going,atDest;
    //to do later: replace these with states 

    void Awake()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();
        destChooser = GetComponent<DestinationChooser>();
        agent = GetComponent<NavMeshAgent>();
        satisfactionText = GameObject.FindGameObjectWithTag("Satisfaction").GetComponent<Text>();
        decayRate = 1f;
        satisfaction = 100;
    }


    void Update()
    {
        if (agent.hasPath)
        {
            going = true;
            waiting = false;
        }
        else
        {
            going = false;
            waiting = true;
        }




        if(waiting && !atDest)
        {
            satisfaction -= decayRate * Time.deltaTime;
        }
        if(going)
        {
            satisfaction -= decayRate * 0.1f * Time.deltaTime;
        }

        if (display)
        {
            satisfactionText.text = "Satisfaction: " + (int)satisfaction;
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
}
