using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class GooglePlayServices : MonoBehaviour
{
    private bool isConnectedToGoogleServices;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        isConnectedToGoogleServices = false;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SocialSignIn();
    }

    public void SocialSignIn()
    {
        if (isConnectedToGoogleServices)
        {
            Debug.Log("Already Signed In");
            if (uiManager != null)
                uiManager.ShowToast("Already Signed In");
            return;
        }

        Social.localUser.Authenticate(success =>
        {
            isConnectedToGoogleServices = success;
        });

        if (!isConnectedToGoogleServices)
            if (uiManager != null)
                uiManager.ShowToast("Error Connecting");

    }



    #region Achievements
    public void UnlockAchievement(string _id)
    {
        _id = "CgkI4seQvfUGEAIQBQ";
        Social.ReportProgress(_id, 100, success =>
        {
            if (!success)
                if (uiManager != null)
                    uiManager.ShowToast("Unlock Error for ID -> " + _id);
        });
    }

    public void IncrementAchievement(string _id, int _incrementRate)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(_id, _incrementRate, success =>
        {
            if (!success)
                if (uiManager != null)
                    uiManager.ShowToast("Unlock Error for ID -> " + _id);

        });
    }

    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
        else
           if (uiManager != null)
            uiManager.ShowToast("Sign in First");
    }
    #endregion


    #region Leaderboard
    public void AddAccoreToLeaderboard(string _id, int _score)
    {
        Social.ReportScore(_score, _id, success =>
        {
            if (!success)
                if (uiManager != null)
                    uiManager.ShowToast("Unlock Error for ID -> " + _id);
        });
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
            Social.ShowLeaderboardUI();
        else
          if (uiManager != null)
            uiManager.ShowToast("Sign in First");
    }
    #endregion


    //SHA1: C0:42:2E:81:1F:56:2E:54:21:E1:A6:05:B8:C8:9F:22:56:13:12:B3
}
