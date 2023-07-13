using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    public PlayerMovement playerMovement;

    private Vector2 initialPosition;
    private Vector2 inputDirection;

    private bool isDragging = false;

    private float handleRadius;
    private float maxDistance;

    private void Awake()
    {
        initialPosition = joystickBackground.position;

        handleRadius = GetComponent<RectTransform>().rect.width * 0.5f;
        maxDistance = (joystickBackground.rect.width - handleRadius) * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 input = eventData.position - initialPosition;
        inputDirection = input.normalized;

        float bgRadius = joystickBackground.rect.width * 0.5f;
        float handleRadius = joystickHandle.rect.width * 0.5f;
        float maxDistance = bgRadius - handleRadius;

        Vector2 handlePosition = inputDirection * maxDistance;
        transform.localPosition = handlePosition;

        playerMovement.SetMovementDirection(inputDirection);
        isDragging = true;
    }    
    

    public void OnPointerUp(PointerEventData eventData)
    {

        if (!isDragging)
        {
            //Handle mouse click input without dragging
            if(!isDragging){
                Vector2 input = eventData.position - initialPosition;
                inputDirection = input.normalized;

                playerMovement.SetMovementDirection(inputDirection);
            }
        }

        isDragging = false;
        inputDirection = Vector2.zero;
        joystickHandle.position = initialPosition;
        playerMovement.SetMovementDirection(inputDirection);
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
