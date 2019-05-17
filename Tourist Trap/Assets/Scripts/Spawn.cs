using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] entryPoints;
    public GameObject tourist;
    GameObject Tourist;
    public int spawnNum, maxTourists, tourists;
    public float timeCounter, timeInterval1, timeInterval2, timeInterval3;
    public bool gameover = false;
    public float timedelay;
    Score scorescript;
    public GameObject gameOver, buttonOver;
    public bool canSpawn;

    private void Start()
    {
        AudioListener.volume = 1;                                                                       //resets volume after scene change
        canSpawn = true;
        scorescript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();

        Time.timeScale = 1;
                                                                                            
        maxTourists = 2;                                                                                //difficulty increases
        timeInterval1 = 30f;
        timeInterval2 = 60f;
        timeInterval3 = 90f;
        timedelay = 3f;


    }

    void FixedUpdate()
    {

        if (gameover)
        {
            scorescript.end = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
            buttonOver.SetActive(true);
        }

        if (canSpawn && timedelay <= 0 && tourists < maxTourists)                                   //time delay in between spawns
        {
            SpawnTourist();
            timedelay = 7f;
        }
        else
        {
            timedelay -= Time.deltaTime;
        }

        timeCounter += Time.deltaTime;

        if (timeCounter >= timeInterval1)                                                           //difficulty increases number of tourists to deal with as time goes on
        {
            maxTourists = 4;
        }

        if (timeCounter >= timeInterval2)
        {
            maxTourists = 6;
        }

        if (timeCounter >= timeInterval3)
        {
            maxTourists = 8;
        }
    }

    private void LateUpdate()
    {
        if (Tourist != null)
        {
            Tourist.GetComponent<SelectedGroup>().destinationWaypoint = entryPoints[spawnNum];
            Tourist = null;
        }
    }
    void SpawnTourist()
    {
        Debug.Log("SpawnAttempted");
        tourists++;
        spawnNum = Random.Range(0, 4);                                                                      //spawns a tourist at a random spawnpoint
        Tourist = Instantiate(tourist, spawnpoints[spawnNum].transform.position, Quaternion.identity);

    }

    public void touristOut()                                                                                //lets the spawnscript know when theres less tourists than the max
    {
        tourists--;
    }

}
