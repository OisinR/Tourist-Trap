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
        panelCanvas.alpha = 0;
    }

    private void Update()
    {
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
    public void OnControls()
    {
        anim.SetBool("ControlsClicked", true);
        anim.SetBool("ControlsShown",true);
        
        //controlspanel.SetActive(true);
    }
    public void OffControls()
    {
        anim.SetBool("ControlsShown", false);
        //controlspanel.SetActive(false);
    }
}
