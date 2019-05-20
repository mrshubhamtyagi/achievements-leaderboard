using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GoogleServicesManager : MonoBehaviour
{
    //public Button openAchievements;
    //public Button openLeaderboard;
    //public Button connectToGS;

    private bool isConnectedToGoogleServices;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        isConnectedToGoogleServices = false;

        Init();

    }

    private void Init()
    {
        PlayGamesPlatform.Activate();
    }

    public void ConnectToGoogleServices()
    {
        string msg = "";

        if (isConnectedToGoogleServices)
        {
            msg = "Already Connected";
            if (uiManager != null)
                uiManager.ShowToast(msg);
            return;
        }

        Social.localUser.Authenticate((bool succes) =>
        {
            isConnectedToGoogleServices = succes;
        });

        //if (!isConnectedToGoogleServices) msg = "Unable to connect";
        //else msg = "Connected";

        //if (uiManager != null)
            //uiManager.ShowToast(msg);

    }

    public void OpenAchievements()
    {
        string msg = "";

        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
        else
        {
            msg = "Unable to open Achievements";
        }

        if (uiManager != null)
            uiManager.ShowToast(msg);

    }

    public void OpenLeaderboard()
    {
        string msg = "";

        if (Social.localUser.authenticated)
            Social.ShowLeaderboardUI();
        else
        {
            msg = "Unable to open Leaderboard";

        }

        if (uiManager != null)
            uiManager.ShowToast(msg);

    }
}
