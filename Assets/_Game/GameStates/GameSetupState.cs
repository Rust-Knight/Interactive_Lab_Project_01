using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    // this is our 'constructor', called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse 
        _stateMachine = stateMachine;
        _controller = controller;

        /*We’re creating something called a Constructor, which is how we can pass in information at the moment this
            object is created. */

        /*Once we receive them, we’ll store them in a local variable in our state so that we can easily reuse the FSM
            and the Controller – caching*/
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("State: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");

        _controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab, _controller.PlayerUnitSpawnLocation);
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

        _stateMachine.ChangeState(_stateMachine.PlayState); // immediately transition into GamePlay in Tick(),
    }
}
