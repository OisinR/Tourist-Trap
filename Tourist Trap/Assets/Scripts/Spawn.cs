using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    public GameObject[] spawnpoints;
    public GameObject tourist;
    public bool gameover = false;
    public float timedelay;
    Score scorescript;
    public GameObject gameOver, buttonOver;
    bool spawning;
    public bool canSpawn;

    private void Start()
    {
        spawning = false;
        canSpawn = true;
        scorescript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();
    }

    void Update()
    {
        if (!spawning && canSpawn)
        {
            
            Time.timeScale = 1;
            InvokeRepeating("SpawnTourist", 2.0f, timedelay);
            //Debug.Log("Online");
            spawning = true;
        }

        if (gameover)
        {
            scorescript.end = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
            buttonOver.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScene");
        }
    }


    void SpawnTourist()
    {
        //Debug.Log("SpawnAttempted");
        if(!(GameObject.FindGameObjectsWithTag("Tourist").Length > 4))
        {
            Instantiate(tourist, spawnpoints[Random.Range(0, 4)].transform.position, Quaternion.identity);
        }
        
    }



    public void RestartGame()
    {
        CancelInvoke();     
        SceneManager.LoadScene(0);
    }
}
