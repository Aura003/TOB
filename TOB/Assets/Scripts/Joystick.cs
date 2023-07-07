using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform JoystickOuter;
    public RectTransform joystickHandle;

    [Tooltip("How much pix it should move, handle will flicker if the range is higher than Half the size of bounds")]
    public float dragDistanceTreshold;
    [Tooltip("Half the size of the outer ring to make sure it does not snap out of bounds")]
    public float dragOffsetSize;

    Vector2 currentPos;

    public event Action<Vector2> Movement;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = JoystickOuter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickHandle, eventData.position, null, out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetSize) / dragOffsetSize;
        joystickHandle.anchoredPosition = offset * dragDistanceTreshold;
        Movement?.Invoke(offset);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        JoystickOuter.position = eventData.position;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickOuter.position = currentPos;
        joystickHandle.anchoredPosition = Vector2.zero;
        Movement?.Invoke(Vector2.zero);
    }
}
