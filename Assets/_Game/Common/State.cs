using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State // Don’t forget to add the keyword ‘abstract’ – this enforces that we cannot create new ‘states’, we can ONLY inherit from States
{
    public float StateDuration { get; private set; } = 0;

    // run once when state is Entered 
    public virtual void Enter()
    {
        StateDuration = 0;
    }

    // run once when state is Exited 
    public virtual void Exit()
    {

    }

    //'abstract' class as – can only be inherited from, not created.
    
    // for Physics 
    public virtual void FixedTick() // this is similar to FixedUpdate()
    {

    }

    // for Update 
    public virtual void Tick() // this is similar to FixedUpdate()
    {
        StateDuration += Time.deltaTime;
    }





}
