using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameCrtl : MonoBehaviour
{
    private const string HighScoreKey = "High Score";
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button gameStart;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    private float scoref;
    private float highScoref = 0;
    private float time;


    public static GameCrtl instance;
    private void Awake()
    {
        instance = this;
    }
    public void StartGameDino()
    {
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        textMeshPro.gameObject.SetActive(true);
        gameStart.gameObject.SetActive(true);
      
    }

    private void Start()
    {
        highScoref = PlayerPrefs.GetFloat(HighScoreKey,0);
        highScore.text = Mathf.RoundToInt(highScoref).ToString("D5");
    }

    public void GameRestart()
    {
        SaveHighScore();
        SceneManager.LoadScene("DinoJump");
    }

    public void Score()
    {   
        time += Time.deltaTime;
        scoref += time * Time.deltaTime;
        score.text = Mathf.RoundToInt(scoref).ToString("D5");
    }

    public void SaveHighScore()
    {
        if (scoref > highScoref)
        {
            highScoref = scoref;
            PlayerPrefs.SetFloat(HighScoreKey, highScoref);
        }
    }

}
