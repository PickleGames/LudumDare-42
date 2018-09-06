using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{

    public Image background;
    public Image joystick;

    public bool enableX, enableY;
    private Vector2 inputVector;

    public float Rotation { get; private set; }

    public float X
    {
        get { return inputVector.x; }
    }

    public float Y
    {
        get { return inputVector.y; }
    }

    void Start()
    {
        //background = this.transform.GetChild(0).GetComponent<Image>();
        //joystick = this.transform.GetChild(1).GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        //Debug.Log(X + " " + Y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform,
                                                                    eventData.position,
                                                                    eventData.pressEventCamera,
                                                                    out position))
        {
            position.x = (position.x / background.rectTransform.sizeDelta.x);
            position.y = (position.y / background.rectTransform.sizeDelta.y);

            inputVector = new Vector2(position.x * 2, position.y * 2);
            inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;
            float x = enableX ? inputVector.x * background.rectTransform.sizeDelta.x / 4 : 0;
            float y = enableY ? inputVector.y * background.rectTransform.sizeDelta.y / 4 : 0;
            joystick.rectTransform.anchoredPosition = new Vector2(x, y);
                                                                  
            //Debug.Log(inputVector);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.rectTransform.anchoredPosition = new Vector2(0, 0);
        inputVector = new Vector2(0, 0);
    }

    /**
     * Rotation in rad
     **/
    private void UpdateRotation()
    {
        Rotation = Mathf.Atan2(Y, X) / 2;
        //Debug.Log("y: " + GetY + " x: " + GetX + " Rotation" + Rotation);
    }
}
