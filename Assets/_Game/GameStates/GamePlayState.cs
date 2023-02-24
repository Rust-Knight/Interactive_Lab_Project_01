using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("State: Game Play");
        Debug.Log("Listen for Player Inputs");
        Debug.Log("Display Player HUD");
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        
        /*if (_controller.Input.IstapPressed == true)
        {

            // check for win condition
            Debug.Log("You Win!");
            // reload level, change back to SetupState, etc.
        }

        else if (StateDuration >= _controller.LoseCondition)
        {
            Debug.Log("You Lose!");
        }
        */
        // check for lose condition
        //Debug.Log("Checking for Win Condition");
       //Debug.Log("Checking for Lose Condition");
    }



}
