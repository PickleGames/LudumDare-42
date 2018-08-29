using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {
    public TextMeshProUGUI[] statTexts;
    public string[] statNames;
    public string[] statNums;
    public static Stats instance;

    public Scoring score;
    public Player player;
    public GameConductor conductor;

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            score = GameObject.Find("Scoring").GetComponent<Scoring>();
            player = GameObject.Find("PlayerBoi").GetComponent<Player>();
            conductor = GameObject.Find("GameConductor").GetComponentInChildren<GameConductor>();
            instance = this;
        }
        else
        {
            instance.Start();
            Destroy(this.gameObject);
        }

    }
    void Start () {
        score = GameObject.Find("Scoring").GetComponent<Scoring>();
        player = GameObject.Find("PlayerBoi").GetComponent<Player>();
        conductor = GameObject.Find("GameConductor").GetComponentInChildren<GameConductor>();
        for (int i = 0; i < statTexts.Length; i++)
        {
            statTexts[i].text = statNames[i] + ": " + statNums[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(SceneManager.GetActiveScene().name == "Nguyen_1" || SceneManager.GetActiveScene().name == "Menu")
        {
            for (int i = 0; i < statTexts.Length; i++)
            {
                statTexts[i].enabled = false;
            }
        }else
        {
            for (int i = 0; i < statTexts.Length; i++)
            {
                statTexts[i].enabled = true;
            }
        }
    }

    public void UpdateStat()
    {
        statNums[0] = "$"+ score.score;
        statNums[1] = ""+ (conductor.stops - 1) + "/" + (conductor.finalStop );
        statNums[2] = ""+ player.GetComponentInChildren<PlayerAttackCollider>().smackedCount;
        for (int i = 0; i < statTexts.Length; i++)
        {
            statTexts[i].text = statNames[i] + ": " + statNums[i];
        }
    }
}
