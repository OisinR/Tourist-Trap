using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {

    public GameObject controlspanel;
    public Animator anim;
    bool controlsClicked,startClicked;
    public CanvasGroup panelCanvas;


    private void Start()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        panelCanvas.alpha = 0;                                      //sets scene chaning panel to transparent
    }

    private void Update()
    {                                                               //transitions to next scene
        if (startClicked)
        {
            if (AudioListener.volume > 0)
            {
                AudioListener.volume -= 0.01f;
            }
            else
            {
                SceneManager.LoadScene("MainScene");
            }
            panelCanvas.alpha += 0.02f;

        }
    }

    public void OnQuit()                                    
    {
        Application.Quit();
    }
    public void OnStart()
    {
        startClicked = true;
    }
    public void OnControls()                                        //sets animaitons for controls panel
    {
        anim.SetBool("ControlsClicked", true);
        anim.SetBool("ControlsShown",true);
        
    }
    public void OffControls()
    {
        anim.SetBool("ControlsShown", false);
    }
}
