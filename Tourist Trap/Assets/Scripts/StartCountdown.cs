using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{

    public float timedelay, number;
    public GameObject number1, number2, number3, start;
    public AudioClip pipSound, startSound;
    AudioSource speaker;

    void Start()
    {
        number = 3;
        timedelay = 1;
        speaker = GetComponent<AudioSource>();
    }




	void Update()
    {
        if (timedelay <= 0)
        {
            timedelay = 1f;
            ShowNum();
        }
        else
        {
            timedelay -= Time.deltaTime;
        }
    }


    void ShowNum()
    {
        if(number == 3)
        {
            speaker.PlayOneShot(pipSound);
            number3.SetActive(true);
            number--;
            return;
        }
        if (number == 2)
        {
            speaker.PlayOneShot(pipSound);
            number3.SetActive(false);
            number2.SetActive(true);
            number--;
            return;
        }
        if (number == 1)
        {
            speaker.PlayOneShot(pipSound);
            number2.SetActive(false);
            number1.SetActive(true);
            number--;
            return;
        }
        if (number == 0)
        {
            speaker.PlayOneShot(startSound);
            number1.SetActive(false);
            start.SetActive(true);
            number--;
            return;
        }
        if (number == -1)
        {
            start.SetActive(false);
            number--;
            return;
        }
        if (number == -2)
        {
            Destroy(this);
        }
    }


}
