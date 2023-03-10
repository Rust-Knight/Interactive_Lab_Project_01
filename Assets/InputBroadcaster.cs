using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // this will allow us to use the Input controller

public class InputBroadcaster : MonoBehaviour
{

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float jumpForce = 5f; // 5f original 

    [SerializeField]
    private bool playerIsJumping;

    private PlayerActionController playerInput;

    private float horizontalMovement; // added for player moving horizontaly

    private float verticalMovement; // added for jumping 

    [SerializeField]
    private Rigidbody2D rigBody;

    void Awake()
    {
        playerInput = new PlayerActionController();
    }

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        playerIsJumping = false;
    }

    void OnEnable()
    {
        playerInput.Player.Enable(); // used for enabling player input controller
    }

    private void OnDisable()
    {
        playerInput.Player.Disable(); // used for disabling player input controller
    }

    void Update()
    {
        horizontalMovement = playerInput.Player.Move.ReadValue<Vector2>().x; // horizontalMovement = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);



        verticalMovement = playerInput.Player.Move.ReadValue<Vector2>().y; // added 


    }

    private void FixedUpdate()
    {


        if (horizontalMovement > 0.1f || horizontalMovement < -0.1f)
        {
            rigBody.AddForce(new Vector2(horizontalMovement * speed, 0f), ForceMode2D.Impulse);
        }

        if (!playerIsJumping && verticalMovement > 0.1f) // added 
        {
            rigBody.AddForce(new Vector2(0f, verticalMovement * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsJumping = true;
        }
    }


}
