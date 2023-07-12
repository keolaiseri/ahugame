using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{


    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    public PlayerMovement playerMovement;

    private Vector2 initialPosition;
    private Vector2 inputDirection;

    private void Awake()
    {
        initialPosition = joystickBackground.position;
    }

    public void OnpointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 input = eventData.position - initialPosition;
        inputDirection = input.normalized;

        float bgRadius = joystickBackground.rect.width * 0.5f;
        float handleRadius = joystickHandle.rect.width * 0.5f;
        fl
    }    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
