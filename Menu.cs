using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.CodeDom;

public class Menu : MonoBehaviour
{
    public static bool gamestart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    public void Update()
    {

    }
    public GameObject HowToPlay;
    public void HowToPlays()
    {
        story.SetActive(false);
        HowToPlay.SetActive(true);
    }
    public GameObject story;
    public void Story()
    {
        story.SetActive(true);
        HowToPlay.SetActive(false);
    }
    public GameObject sound_on;
    public GameObject sound_off;
    public void sound_ON()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);

    }
    public void sound_OFF()
    {
        sound_off.SetActive(true);
        sound_on.SetActive(false);

    }
    public GameObject x;
    public void X()
    {
        HowToPlay.SetActive(false);
        story.SetActive(false);
    }
    public GameObject x_2;
    public void X_2()
    {
        HowToPlay.SetActive(false);
        story.SetActive(false);
    }

    public GameObject startbutton;
    public void start()
    {
        Score_System.gamestart = true;

        Player_Control.boosttimer = 0;
        Player_Control.teleportimer = 0;

        SceneManager.LoadScene("Final");    

    }
    public GameObject Exitbutton;
    public void Exit()
    {
        Application.Quit();
    }
}

