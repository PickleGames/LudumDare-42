using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour {

	void Start () {
        ChangeSprite();
    }

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            JukeBox.Instance.ToggleMusic();
            ChangeSprite();
        });
    }

    private void ChangeSprite()
    {
        JukeBox juke = JukeBox.Instance;
        string path = juke.isPlay ? "Sprites/UI/MusicUI" : "Sprites/UI/MusicUI_X";
        Sprite sp = Resources.Load<Sprite>(path);
        this.GetComponent<Image>().sprite = sp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
