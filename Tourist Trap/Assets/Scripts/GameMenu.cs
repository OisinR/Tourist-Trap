using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    bool menu,mainMenuClicked;
    public GameObject controlspanel;
    public Animator anim;
    public CanvasGroup panelCanvas;
    public GameObject panelObject;



    void Start()
    {
        panelObject.SetActive(true);            //sets scene change panel to transparent
        panelCanvas.alpha = 0;
    }


	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))       //enables and disables the menu
        {
            menu = !menu;
            if(!menu)
            {
                MenuFalse();
            }
        }


        if (menu)
        {
            Menu();
        }
        else
        {
            controlspanel.SetActive(false);
        }


        if (mainMenuClicked)                                //fades out visuals and audio when changing scenes
        {
            if (AudioListener.volume > 0)
            {
                AudioListener.volume -= 0.01f;
            }
            else
            {
                SceneManager.LoadScene("StartScene");
            }

            panelCanvas.alpha += 0.02f;

        }
    }


    void Menu()
    {
        Time.timeScale = 0;             
        controlspanel.SetActive(true);
    }

    public void MenuFalse()
    {
        menu = false;
        Time.timeScale = 1;
    }



    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        mainMenuClicked = true;
    }

    public void OnControls()                                    //sets animaitons for the control panel sliding in and out
    {   
        anim.SetBool("ControlsClicked", true);
        anim.SetBool("ControlsShown", true);

    }
    public void OffControls()
    {
        anim.SetBool("ControlsShown", false);
    }
}

