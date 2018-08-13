using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour {

    public Transform player;
    public Camera cam;
    public string[] dialouge; 

    private SpriteRenderer playerSpriteRenderer;
    private Vector3 spriteSize;
    private Image bubble;
    private TextMeshProUGUI text;

    public bool IsEnable { get; private set; }
    public Vector2 bubbleScale; // x: 12, y : 7 

    private float timeElapsedBubble;
    private const float TIME_BUBBLE = 1f;
    private string currentText;

	void Start () {
        bubble = this.GetComponent<Image>();
        text = this.GetComponentInChildren<TextMeshProUGUI>();

        playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        spriteSize = playerSpriteRenderer.bounds.size;

        RandomText();
        DisableSpeech();
	}
	
	// Update is called once per frame
	void Update () {
        spriteSize = playerSpriteRenderer.bounds.size * 100;
        //Debug.Log(spriteSize);
        //Debug.Log(playerSpriteRenderer.sprite.texture.width * playerSpriteRenderer.transform.localScale.x);
        //Debug.Log(playerSpriteRenderer.sprite.texture.height * playerSpriteRenderer.transform.localScale.y);
        Vector3 playerScreenPos = cam.WorldToScreenPoint(player.position);
        this.transform.position = new Vector3(playerScreenPos.x + Screen.width / bubbleScale.x,
                                              playerScreenPos.y + Screen.height / bubbleScale.y, 
                                              playerScreenPos.z);

        //this.transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
        if (IsEnable)
        {
            timeElapsedBubble += Time.deltaTime;
            if(timeElapsedBubble >= TIME_BUBBLE)
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
        bubble.enabled = true;
        text.enabled = true;
    }

    public void DisableSpeech()
    {
        RandomText();
        bubble.enabled = false;
        text.enabled = false;
    }

    private void RandomText()
    {
        int val = Random.Range(0, dialouge.Length);
        currentText = dialouge[val];
        text.text = currentText;
    }
}
