//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using UnityEngine.SocialPlatforms;
//public class PlayGamesManager : MonoBehaviour
//{
//    private static PlayGamesManager instance;

//    void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//            InitializePlayGames();
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    void InitializePlayGames()
//    {
//        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
//        PlayGamesPlatform.InitializeInstance(config);
//        PlayGamesPlatform.Activate();

//        // Sign in to Google Play Games
//        Social.localUser.Authenticate(success => {
//            if (success)
//            {
//                Debug.Log("Successfully logged in to Google Play Games");
//            }
//            else
//            {
//                Debug.LogWarning("Failed to log in to Google Play Games");
//            }
//        });
//    }

//    public static void ShowLeaderboard(string leaderboardId)
//    {
//        if (Social.localUser.authenticated)
//        {
//            PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardId);
//        }
//        else
//        {
//            Debug.LogWarning("Cannot show leaderboard, user not authenticated");
//        }
//    }
//}
