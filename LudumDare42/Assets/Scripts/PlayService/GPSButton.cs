using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSButton : MonoBehaviour {
    public enum GPSType
    {
        Achievement, LeaderBoard, Login, Logout, Default
    }

    public GPSType gpsType;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            switch (gpsType)
            {
                case GPSType.Achievement:
                    GooglePlayService.instance.ShowAchievementUI();
                    break;
                case GPSType.LeaderBoard:
                    GooglePlayService.instance.ShowLeaderboadUI();
                    break;
                case GPSType.Login:
                    GooglePlayService.instance.SignIn();
                    break;
                case GPSType.Logout:
                    GooglePlayService.instance.SignOut();
                    break;
                default:
                    break;
            }
            
        });
    }
}
