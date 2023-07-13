using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform background; // Reference to the background Image object
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private Vector2 initialPosition;
    private Vector2 inputDirection;
    private bool isDragging = false;

    private float handleRadius;
    private float maxDistance;

    private void Awake()
    {
        initialPosition = background.position;

        handleRadius = GetComponent<RectTransform>().rect.width * 0.5f;
        maxDistance = (background.rect.width - handleRadius) * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 input = GetLocalInput(eventData);
            inputDirection = input.normalized;

            Vector2 handlePosition = inputDirection * maxDistance;
            transform.localPosition = Vector2.ClampMagnitude(handlePosition, maxDistance);

            playerMovement.SetMovementDirection(inputDirection);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            transform.localPosition = Vector2.zero;
            inputDirection = Vector2.zero;
            playerMovement.SetMovementDirection(inputDirection);
        }
    }

    private Vector2 GetLocalInput(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, null, out localPos);
        return localPos;
    }
}
