using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score_System : MonoBehaviour
{
    public static Score_System instance;

    public TMP_Text scoreTexts, comboTexts;
    public TMP_Text boosterCountDown, teleportCountDown;
    public Image[] hearths = new Image[0];
    public Image[] dmg = new Image[0];
    public Image sheilds;
    public static bool gamestart = true;

    
    public TMP_Text resultScore;

    public GameObject comboWindow;
    public GameObject BoosterIcon, teleportIcon;

    public int scores, scoreDif = 0;
    public int life = 0;
    public int combos;
    public int combotimes;


    public static bool isPaused = false;
    public static AudioSource BGM;

    private ResultWin resultWin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        resultWin = FindObjectOfType<ResultWin>();

        isPaused = false;
        Time.timeScale = 1f;
        scores = 0;
        scoreDif = 0;
        BGM = GetComponent<AudioSource>();
    }

    void UpdateHearths()
    {
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < life)
            {
                hearths[i].gameObject.SetActive(false);
                dmg[i].gameObject.SetActive(true);
            }
            else
            {
                hearths[i].gameObject.SetActive(true);
                dmg[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("HighScore Deleted!");
        }

        if (combos >= 100)
        {
            comboWindow.SetActive(true);
            comboTexts.text = $"{combos} Combo!";
            comboTexts.color = new Color32(255, 61, 0, 255);
        }
        else if (combos >= 50)
        {
            comboWindow.SetActive(true);
            comboTexts.text = $"{combos} Combo!";
            comboTexts.color = new Color32(255, 181, 0, 255);
        }
        else if (combos >= 2)
        {
            comboWindow.SetActive(true);
            comboTexts.text = $"{combos} Combo!";
            comboTexts.color = Color.cyan;
        }
        else
        {
            comboWindow.SetActive(false);
        }

        
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < life)
            {
                hearths[i].gameObject.SetActive(false);
                dmg[i].gameObject.SetActive(true);
            }
        }
        if (life >= hearths.Length)
        {
            SceneManager.LoadScene("Score");
        }



        if (Player_Control.shield)
        {
            sheilds.color = Color.white;
        }
        else
        {
            sheilds.color = Color.gray;
        }

        if (Player_Control.booster)
        {
            BoosterIcon.SetActive(true);
            int boostertimerint = (int)Player_Control.boosttimer;
            boosterCountDown.text = boostertimerint.ToString();
        }

        if (!Player_Control.booster)
        {
            BoosterIcon.SetActive(false);
        }

        if (Player_Control.teleporter)
        {
            teleportIcon.SetActive(true);
            int teleporttimerint = (int)Player_Control.teleportimer;
            teleportCountDown.text = teleporttimerint.ToString();
        }

        if (!Player_Control.teleporter)
        {
            teleportIcon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }
    public GameObject Pause;
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // ทำให้เวลาหยุด
            // ใส่โค้ดเพิ่มเติมที่คุณต้องการในขณะที่เกมถูกพัก
            Pause.SetActive(true);
            BGM.mute = true;
        }
        else
        {
            Time.timeScale = 1f; // ทำให้เวลาเป็นปกติ
            // ใส่โค้ดเพิ่มเติมที่คุณต้องการในขณะที่เกมทำงาน
            Pause.SetActive(false);
            BGM.mute = false;
        }
    }

    public void ScoreUpdate(int Scorem)
    {
        scores += Scorem;
        scoreDif += Scorem;
        scoreTexts.text = $" : {scores}";
    }

    public void Checkhighscore()
    {
        if (scores > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", scores);
        }
    }

    public GameObject home;
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
