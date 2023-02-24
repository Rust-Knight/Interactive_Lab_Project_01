using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    // state variables here 

    // add states here
    public GameSetupState SetupState { get; private set; } // Here we’re holding on to our instance of the State we just created.
    public GamePlayState PlayState { get; private set;  } // add this state with win and lose

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state instantiation here 
        SetupState = new GameSetupState(this, _controller); // 
        PlayState = new GamePlayState(this, _controller); // determine our Transition into condition
    }

    private void Start() 
    {
        ChangeState(SetupState); // defining a starting state for state machine
    }

}
