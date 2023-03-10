using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControls : MonoBehaviour
{

    public Animator animator;

    bool facingRight = true;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float jumpForce = 5f; // 5f original 

    [SerializeField]
    private bool playerIsJumping;

    private PlayerActionController playerInput;

    private float horizontalMovement; // added for player moving horizontaly

    private float verticalMovement; // added for jumping 

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


        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));


    }

    private void FixedUpdate() // FixedUpdate is dedicated for physics  
    {
      

        if(horizontalMovement > 0.1f || horizontalMovement < -0.1f)
        {
            rigBody.AddForce(new Vector2(horizontalMovement * speed, 0f), ForceMode2D.Impulse);
            
        }

        if(horizontalMovement > 0 && !facingRight) // will flip player sprite 
        {
            Flip();
        }

        if (horizontalMovement < 0 && facingRight) // will flip player sprite 
        {
            Flip();
        }


        if ( !playerIsJumping && verticalMovement > 0.1f) // added 
        {
            rigBody.AddForce(new Vector2(0f, verticalMovement * jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsJumping = false;
            animator.SetBool("IsJumping", false);// added for jumping animation
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsJumping = true;
            
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight; // means the opposite of what it is right now 

    }

}
