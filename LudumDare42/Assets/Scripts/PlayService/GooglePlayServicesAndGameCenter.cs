using System.Text;
using UnityEngine;

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;


public class GooglePlayServicesAndGameCenter : MonoBehaviour {

    public static GooglePlayServicesAndGameCenter instance;
    public static bool IsConnectedToGameServices { get { return isConnectedToGameServices; } }

    public static bool isConnectedToGameServices;

    private const string SAVE_NAME = "Seal";
    //private bool isSaving;
    //private bool isCloudDataLoaded = false;

    private bool isAchievementCall;
    private bool isLeaderBoardCall;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        //if (!PlayerPrefs.HasKey(SAVE_NAME))
        //{
        //    PlayerPrefs.SetString(SAVE_NAME, "0");
        //}
        //if (!PlayerPrefs.HasKey("IsFirstTime"))
        //{
        //    PlayerPrefs.SetInt("IsFirstTime", 1);
        //}

        //LoadLocal();

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        //isConnectedToGameServices = ConnectToGoogleServices();

    }

    private void Update()
    {
        //Debug.Log("Google Play Connection Status: " + IsConnectedToGoogleServices);
    }

    private bool ConnectToGoogleServices()
    {
        PlayGamesPlatform.Instance.Authenticate(success =>
        {
            isConnectedToGameServices = success;
            if (success)
            {
                SetPopUpGravity();
                Debug.Log("Login success");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
        //PlayGamesPlatform.Instance.IsAuthenticated();

        //Social.localUser.Authenticate((bool success) =>
        //{
        //    isConnectedToGameServices = success;
        //    if (success)
        //    {
        //        SetPopUpGravity();
        //        Debug.Log("Login success");
        //    }
        //    else
        //    {
        //        Debug.Log("Login Failed");
        //    }
        //});
        Debug.Log("Google Play Connection Status: " + IsConnectedToGameServices);
        return IsConnectedToGameServices;
    }

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => {
            isConnectedToGameServices = success;
            if (success)
            {
                //LoadData();
                SetPopUpGravity();
                Debug.Log("Login success");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
        Debug.Log("Google Play Connection Status: " + IsConnectedToGameServices);
    }

    private void SetPopUpGravity()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);
            }
        });
    }

    public void Logout()
    {
#if UNITY_ANDROID
        ((PlayGamesPlatform)Social.Active).SignOut();
#endif
    }

    public void ShowAchievement()
    {
        if (!isAchievementCall)
        {
            Debug.Log("Show Achievement is clicked");
            Social.ShowAchievementsUI();
            isAchievementCall = true;
        }
    }

    public void ShowLeaderBoard()
    {
        if (!isLeaderBoardCall)
        {
            Debug.Log("Show leader board is clicked");
            Social.ShowLeaderboardUI();
            isLeaderBoardCall = true;
        }
    }

    public void UnlockAchievement(string code)
    {
        Social.ReportProgress(code, 100.0f, (bool success) => {
            Debug.Log(success ? "Achievement Unlock" : "Failed Unlock");
        });
    }

    public void PostLeaderBoard(string code, int score)
    {
        Social.ReportScore(score, code, (bool success) => {
            Debug.Log(success ? "Post score success" : "Failed post score");
        });
    }

    public int RetrieveLeaderBoardScore(string code)
    {
        int score = 0;
        PlayGamesPlatform.Instance.LoadScores(
               code,
               LeaderboardStart.PlayerCentered,
               1,
               LeaderboardCollection.Public,
               LeaderboardTimeSpan.AllTime,
               (LeaderboardScoreData data) => {
                   Debug.Log(data.Valid);
                   Debug.Log(data.Id);
                   Debug.Log(data.PlayerScore);
                   Debug.Log(data.PlayerScore.userID);
                   Debug.Log(data.PlayerScore.formattedValue);
                   score = System.Int32.Parse(data.PlayerScore.formattedValue);
               });
        return score;
    }

    //public void LoadData()
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        isSaving = false;
    //        ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(
    //            SAVE_NAME,
    //            DataSource.ReadCacheOrNetwork,
    //            true,
    //            ResolveConflict,
    //            OnSavedGameOpened
    //            );
    //    }
    //    else
    //    {
    //        LoadLocal();
    //    }
    //}

    //private void LoadLocal()
    //{
    //    StringToGameData(PlayerPrefs.GetString(SAVE_NAME));
    //}

    //public void SaveData()
    //{
    //    if (!isCloudDataLoaded)
    //    {
    //        SaveLocal();
    //        return;
    //    }
    //    if (Social.localUser.authenticated)
    //    {
    //        isSaving = true;
    //        ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(
    //            SAVE_NAME,
    //            DataSource.ReadCacheOrNetwork,
    //            true,
    //            ResolveConflict,
    //            OnSavedGameOpened
    //            );
    //    }
    //    else
    //    {
    //        SaveLocal();
    //    }
    //}

    //private void SaveLocal()
    //{
    //    PlayerPrefs.SetString(SAVE_NAME, GameDataToString());
    //}

    //private void ResolveConflict(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData, ISavedGameMetadata unmerged, byte[] unmergedData)
    //{
    //    if (originalData == null)
    //    {
    //        resolver.ChooseMetadata(unmerged);
    //    }
    //    else if (unmergedData == null)
    //    {
    //        resolver.ChooseMetadata(original);
    //    }
    //    else
    //    {
    //        string originalString = Encoding.ASCII.GetString(originalData);
    //        string unmergedString = Encoding.ASCII.GetString(unmergedData);

    //        int originalNum = int.Parse(originalString);
    //        int unmergedNum = int.Parse(unmergedString);

    //        if (originalNum > unmergedNum)
    //        {
    //            resolver.ChooseMetadata(original);
    //            return;
    //        }
    //        else if (unmergedNum > originalNum)
    //        {
    //            resolver.ChooseMetadata(unmerged);
    //            return;
    //        }
    //    }
    //}

    //private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    //{
    //    if (status == SavedGameRequestStatus.Success)
    //    {
    //        if (!isSaving)
    //        {
    //            LoadGame(game);
    //        }
    //        else
    //        {
    //            SaveGame(game);
    //        }
    //    }
    //    else
    //    {
    //        if (!isSaving)
    //        {
    //            LoadLocal();
    //        }
    //        else
    //        {
    //            SaveLocal();
    //        }
    //    }
    //}

    //private void LoadGame(ISavedGameMetadata game)
    //{
    //    ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(game, OnSavedGameDataRead);
    //}

    //private void SaveGame(ISavedGameMetadata game)
    //{
    //    string stringToSave = GameDataToString();
    //    PlayerPrefs.SetString(SAVE_NAME, stringToSave);

    //    byte[] dataToSave = Encoding.ASCII.GetBytes(stringToSave);
    //    SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
    //    ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(game, update, dataToSave, OnSavedGameDataWritten);


    //}

    //private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] savedData)
    //{
    //    if (status == SavedGameRequestStatus.Success)
    //    {
    //        string cloudDataString;
    //        if (savedData.Length == 0)
    //        {
    //            cloudDataString = "0";
    //        }
    //        else
    //        {
    //            cloudDataString = Encoding.ASCII.GetString(savedData);
    //        }

    //        string localDataString = PlayerPrefs.GetString(SAVE_NAME);
    //        StringToGameData(cloudDataString, localDataString);
    //    }
    //}

    //private void OnSavedGameDataWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    //{

    //}

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            isLeaderBoardCall = false;
            isAchievementCall = false;
        }
    }
}
