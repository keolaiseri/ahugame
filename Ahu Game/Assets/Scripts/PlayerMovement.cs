using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public SpriteRenderer playerSprite;

    private Vector2 movementDirection;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
      MovePlayer();
    }

    public void SetMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
        UpdatePlayerSpriteDirection();
    }
    
    private void MovePlayer()
    {
        Vector2 movement = movementDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void UpdatePlayerSpriteDirection()
    {
        if (movementDirection.x < 0)
        {
            playerSprite.flipX = true; //Face Left
        }
        else if (movementDirection.x > 0)
        {
            playerSprite.flipX = false; // Face Right
        }
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
