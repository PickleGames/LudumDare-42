using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GooglePlayService : MonoBehaviour {

    public static GooglePlayService instance;
	
	void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestEmail()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SignIn()
    {
        // authenticate user:
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (success)
            {
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);
                Debug.Log("Login succesful");
            }else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public void ShowAchievementUI()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowLeaderboadUI()
    {
        Social.ShowLeaderboardUI();
    }

}
