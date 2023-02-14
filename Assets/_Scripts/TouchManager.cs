using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // this will allow us to use the Input controller

public class TouchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player; // To get the transform of the player the location on the world 

    private PlayerInput playerInput;

    private InputAction touchPositionAction; // Variables for actions 
    private InputAction touchPressAction; // Variables for actions 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"]; // reference to our actions
        touchPositionAction = playerInput.actions["TouchPosition"]; // This is Cap Sensitive
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;// subscribed from events 
    }

    private void OnDisable() // - means we want to unsubscribed from events
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context) // information regarding our action that has been performed 
    {

        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());  // Convert wherever we're tapping to from screen to World coordinates 

        position.z = player.transform.position.z; // set z to what it was before in this case our Player 

        player.transform.position = position;

    }

}

