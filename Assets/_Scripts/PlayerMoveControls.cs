using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControls : MonoBehaviour
{


    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private bool playerGrounded;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    private PlayerActionController playerInput;

    private float horizontalMovement;
    private bool playerJumpTriggered;


    private Rigidbody2D rigBody;

    void Awake()
    {
        playerInput = new PlayerActionController();
    }

    private void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    void Update()
    {
        horizontalMovement = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);

        playerGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.01f, groundLayer); //OverlapCircle


        if (playerInput.Player.Jump.triggered)
        {
            //rigBody.velocity = new Vector2(rigBody.position.x, jumpForce);

            playerJumpTriggered = true;
        }

        
       


    }

    private void FixedUpdate()
    {
        var velocityX = speed * horizontalMovement;
        rigBody.velocity = new Vector2(velocityX, rigBody.velocity.y);

        if (playerJumpTriggered && playerGrounded)
        {
            playerJumpTriggered = false;
            rigBody.velocity = new Vector2(rigBody.position.x, jumpForce);
        }
    }


}
