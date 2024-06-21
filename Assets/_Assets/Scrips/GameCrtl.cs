using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameCrtl : MonoBehaviour
{
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button pauseGame;
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
    
    public bool connectToGooglePlay;
    
    private void Awake()
    {   
        instance = this;
        StartCoroutine(DisplayBannerWithDelay());
        
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

    }
    
    private void Start()
    {   
        SignIn();
        gamePlayed = PlayerPrefs.GetInt("GamePlayed", 1);   
        highScoref = PlayerPrefs.GetFloat(HighScoreKey,0);
        highScore.text = Mathf.RoundToInt(highScoref).ToString("D6");

    }

    public void SignIn()
    {   
        Debug.Log(("DEBUG IN HERE ===================================================="));
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    public void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success) { Debug.Log("Login SUCCESS"); }

        else { Debug.Log("Login FAIL"); }

    }

    private void LeaderboardUpdate(bool succes)
    {
        if(succes) Debug.Log("Update LeaderBoard");
        else Debug.Log("Unable to update leaderboard");
    }
    public void GameRestart()
    {
        SaveHighScore();
        SceneManager.LoadScene("DinoJump");
        CactusMove.speed = 16f;
        Time.timeScale = 0;
        gamePlayed++;   
        PlayerPrefs.SetInt("GamePlayed", gamePlayed);
        
        Social.ReportScore((long)highScoref, GPGSIds.leaderboard_dinorunner, LeaderboardUpdate);    
    }
    
    public void ShowLeaderBoard()
    {
        // if(!connectToGooglePlay) LogInToGooglePlay();
        Social.ShowLeaderboardUI();
    }
    
    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAds();
    }
    public void StartGameDino()
    {   
        MenuPause.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        pauseGame.gameObject.SetActive(true);
        Time.timeScale = 0;
        textMeshPro.gameObject.SetActive(true);
        gameStart.gameObject.SetActive(true);
        dinoMove.onAir = true;
        MenuPause.gameObject.SetActive(false);
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        

        if (gamePlayed % 6 == 0)
        {
            AdsManager.Instance.interstitialAds.ShowInterstitialAds();
        }
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
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pause.gameObject.SetActive(false);
        continueGame.gameObject.SetActive(false);
        buttonLeft.gameObject.SetActive(true);
        buttonRight.gameObject.SetActive(true);
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

    public void StartGame()
    {
        buttonStart.gameObject.SetActive(false);
        Time.timeScale = 1f;
        touchToStart.enabled = false;
        pauseGame.gameObject.SetActive(true);
    }
    
}
