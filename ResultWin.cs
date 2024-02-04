using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ResultWin : MonoBehaviour
{
    [SerializeField]
    public TMP_Text resultText;

    [SerializeField]
    public TMP_Text resultScore;

    [SerializeField]
    public TMP_Text highScoreText;

    void Start()
    {
        Debug.Log("Start of ResultWin");
        UpdateHighscore();
        Menu Menu = FindObjectOfType<Menu>();




        if (Score_System.instance.scores >= 3000)
            {
                resultText.text = ("You Win");
                Debug.Log("Win");
                resultScore.text = Score_System.instance.scores.ToString();
                Checkhighscore();
            }
            else
            {
                resultText.text = ("You Lose");
                Debug.Log("lose!");
                resultScore.text = Score_System.instance.scores.ToString();
                Checkhighscore();
            }
        

        resultScore = Score_System.instance.resultScore;

        Debug.Log("End of ResultWin");
    }

    public void RestartGame()
    {
        Score_System.instance.life = 0;
        Score_System.instance.combos = 0;
        Score_System.instance.scores = 0;

        Player_Control.boosttimer = 0;
        Player_Control.teleportimer = 0;

        Score_System.gamestart = true;
        SceneManager.LoadScene("Final");
    }

    public void Checkhighscore()
    {
        if (Score_System.instance.scores > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", Score_System.instance.scores);
        }
    }

    public void UpdateHighscore()
    {
        highScoreText.text = $"{PlayerPrefs.GetInt("Highscore",0)}";
    }

    public GameObject home;
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
