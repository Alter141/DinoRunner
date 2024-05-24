using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameCrtl : MonoBehaviour
{
    [SerializeField] private Button SoundOn;
    [SerializeField] private Button SoundOff;
    [SerializeField] private Button MenuPause;
    [SerializeField] private TextMeshProUGUI pause;
    [SerializeField] private Button continueGame;
    [SerializeField] private TextMeshProUGUI touchToStart;
    [SerializeField] private DinoMove dinoMove;
    private const string HighScoreKey = "High Score";
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button gameStart;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    private float scoref;
    private float highScoref ;
    private float time;
    private float checkTime;
    private int gamePlayed;
    public static GameCrtl instance;

  
    private void Awake()
    {   
        instance = this;
        StartCoroutine(DisplayBannerWithDelay());
    }

    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAds();
    }
    public void StartGameDino()
    {
        MenuPause.gameObject.SetActive(true);
        touchToStart.enabled = false;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        textMeshPro.gameObject.SetActive(true);
        gameStart.gameObject.SetActive(true);
        dinoMove.onAir = true;
        MenuPause.gameObject.SetActive(false);
        
        if (gamePlayed % 3 == 0)
        {
            AdsManager.Instance.interstitialAds.ShowInterstitialAds();
        }
    }   

    private void Start()
    {
        gamePlayed = PlayerPrefs.GetInt("GamePlayed", 1);   
        highScoref = PlayerPrefs.GetFloat(HighScoreKey,0);
        highScore.text = Mathf.RoundToInt(highScoref).ToString("D6");
    }

    private void Update()
    {   
        checkTime += Time.deltaTime;
        if(CactusMove.speed <= 21)
        {
            if (checkTime >= 60)
            {
                BirdFly.speed += 0.5f;
                CactusMove.speed += 0.5f;
                checkTime = 0;
            }
        }
    }
    public void GameRestart()
    {
        SaveHighScore();
        SceneManager.LoadScene("DinoJump");
        CactusMove.speed = 16f;
        Time.timeScale = 0;
        gamePlayed++;   
        PlayerPrefs.SetInt("GamePlayed", gamePlayed);
    }

    public void Score()
    {   
        time += Time.deltaTime;
        scoref += time * Time.deltaTime;
        score.text = Mathf.RoundToInt(scoref).ToString("D6");
    }
    
    
    public void SaveHighScore()
    {
        if (scoref > highScoref)
        {
            highScoref = scoref;
            PlayerPrefs.SetFloat(HighScoreKey, highScoref);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pause.gameObject.SetActive(true);
        continueGame.gameObject.SetActive(true);
        DinoMove.fix = false;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pause.gameObject.SetActive(false);
        continueGame.gameObject.SetActive(false);
    }

    public void ShowIconSound()
    {
        SoundOn.gameObject.SetActive(true);
        SoundOff.gameObject.SetActive(false);
    }

    public void ShowIconSoundOff()
    {
        SoundOff.gameObject.SetActive(true);
        SoundOn.gameObject.SetActive(false);
    }
}
