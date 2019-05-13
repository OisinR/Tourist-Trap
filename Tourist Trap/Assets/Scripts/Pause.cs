using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject pause;
    bool paused;
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            paused = !paused;
        }

            if (paused)
            {
                pause.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            }
            if(!paused)
            {
                pause.SetActive(false);
                paused = false;
                Time.timeScale = 1;
            }
            
        
    }


    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
