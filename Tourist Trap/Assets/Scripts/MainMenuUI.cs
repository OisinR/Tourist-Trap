using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {

    public GameObject controlspanel;

    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnControls()
    {
        controlspanel.SetActive(true);
    }
}
