using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject controls;
    public Spawn script;

    private void Start()
    {
        Time.timeScale = 0;
    }



    public void CloseAndPlay()
    {
        script.canSpawn = true;
        Time.timeScale = 1;
        controls.SetActive(false);
    }
}
