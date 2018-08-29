using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Transform player;
    public Camera cam;
    public string[] dialouge;

    private SpriteRenderer playerSpriteRenderer;
    private Vector3 spriteSize;
    private TextMeshProUGUI text;

    public bool IsEnable { get; private set; }
    private float timeElapsedBubble;
    private const float TIME_BUBBLE = 1f;
    private string currentText;

    void Start()
    {
        text = this.GetComponentInChildren<TextMeshProUGUI>();

        playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        spriteSize = playerSpriteRenderer.bounds.size * 100;

        RandomText();
        DisableSpeech();
    }

    float timer, delay = 2;
    // Update is called once per frame
    void Update()
    {
        Vector3 playerScreenPos = cam.WorldToScreenPoint(player.position);
        this.transform.position = new Vector3(playerScreenPos.x + spriteSize.x/4,
                                              playerScreenPos.y + spriteSize.y/4,
                                              playerScreenPos.z);

        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = 0;
            EnableSpeech();
            delay = Random.Range(1f, 3f);
        }
        if (IsEnable)
        {
            timeElapsedBubble += Time.deltaTime;
            if (timeElapsedBubble >= TIME_BUBBLE)
            {
                IsEnable = false;
                timeElapsedBubble = 0;
                DisableSpeech();
            }
        }
    }

    public void EnableSpeech()
    {
        IsEnable = true;
        text.enabled = true;
    }

    public void DisableSpeech()
    {
        RandomText();
        text.enabled = false;
    }

    private void RandomText()
    {
        int val = Random.Range(0, dialouge.Length);
        currentText = dialouge[val];
        text.text = currentText;
    }
}
