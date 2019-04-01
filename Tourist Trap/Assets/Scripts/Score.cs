using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    Satisfaction satScript;
    public int highscore;
    public int score;
    public bool end;
    public Text scoreText;
    public Text highScoreText;
    void Start()
    {
        
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        highScoreText = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>();
        score = 0;
        end = false;
        highscore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        //Reset
        //PlayerPrefs.SetInt("Highscore", 0);

        if (!end)
        {
            if (score > highscore)
            {
                highscore = score;
            }
            highScoreText.text = "Highscore: " + highscore + "  ";           
            scoreText.text = "Score: " + score + "  ";

            
        }
        else
        {
            if(score > PlayerPrefs.GetInt("Highscore"))
            {
                highscore = score;
                PlayerPrefs.SetInt("Highscore",highscore);
            }
        }
    }



    public void displayScore(float satisfaction)
    {
        score += 100 + (int)satisfaction;
    }
}
