using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCart : MonoBehaviour {

    public const int MAX_PEOPLE = 10;
    public const float DURABILITY_DAMAGE = 0.1f;
    public const float TIME_DESTROY = 2f;
    public const float MAX_DURABILITY = 100;

    public bool IsBreak { get; set; }
    public int numberOfPeople;
    public float Durability { get; set; }

    public List<GameObject> aiList;
    public bool allowIncreasePoint = true;

    private float timeElapsed;
    private bool isColorChanged;
    private float timeColorElapsed;

    void Start () {
        aiList = new List<GameObject>();
        Durability = 100;    	
	}
	
	void Update () {
        //if (allowIncreasePoint)
        //{
        //}
            Scoring.Instance.AddScore(10*numberOfPeople, 2);

        if (!Train.IsAtTrainStation)
        {
            ReduceDurability();
        }

        if (IsBreak)
        {
            timeElapsed += Time.deltaTime;
        }

        if(timeElapsed >= TIME_DESTROY)
        {
            Destroy(transform.gameObject);
            KillAll();
        }

        if (Durability < MAX_DURABILITY * .60f)
        {
            if (Durability < MAX_DURABILITY * .30f) { 
                CameraShake.Instance.isContinueShake = true;
            }
            if (!isColorChanged)
            {
                StartCoroutine(FlashColor());
            }

        }

    }

    public int GainPoints()
    {
        return numberOfPeople != 0 ? Mathf.Clamp(numberOfPeople + MAX_PEOPLE, 10, 20) : 0;
    }

    public void BoomBoom()
    {
        IsBreak = true;
    }

    public void RemovePeople(GameObject go)
    {
        numberOfPeople -= 1;
        aiList.Remove(go);
    }

    public void ChangePeopleRenderer(bool isEnable)
    {
        for (int i = 0; i < aiList.Count; i++)
        {
            SpriteRenderer sr = aiList[i].GetComponentInChildren<SpriteRenderer>();
            sr.enabled = isEnable;
        }
    }

    public void KillAll()
    {
        for (int i = 0; i < aiList.Count; i++)
        {
            aiList[i].GetComponent<AI>().FlyAway();

        }
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
        isColorChanged = false;
    }

    private IEnumerator FlashColor()
    {
        isColorChanged = true;
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();

        sr.color = new Color(1f, Durability/MAX_DURABILITY , Durability / MAX_DURABILITY, 1f);
        yield return new WaitForSeconds(.3f * Durability / MAX_DURABILITY + .05f);
        sr.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(.3f + Durability / MAX_DURABILITY + .05f);
        sr.color = new Color(1f, Durability / MAX_DURABILITY, Durability / MAX_DURABILITY, 1f);
        yield return new WaitForSeconds(.3f + Durability / MAX_DURABILITY + .05f);
        sr.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(.3f + Durability / MAX_DURABILITY + .05f);
        isColorChanged = false;
    }

    private void ReduceDurability()
    {
        if(numberOfPeople > MAX_PEOPLE)
        {
            Durability -= DURABILITY_DAMAGE * (numberOfPeople / MAX_PEOPLE);
        }
        if (Durability <= 0) IsBreak = true;
    }

    // check if AI have entered and exited train cart area, adjust contacts accordingly
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AI"))
        {
            numberOfPeople += 1;
            aiList.Add(collision.gameObject);
            collision.gameObject.GetComponent<AI>().trainCart = this;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("AI"))
        {
            RemovePeople(other.gameObject);
        } 
    }

}
